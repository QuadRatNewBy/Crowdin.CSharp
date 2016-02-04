﻿namespace Crowdin.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

    internal class CrowdinRequest : ICrowdinRequest
    {
        private readonly IList<KeyValuePair<string, object>> body;

        private readonly IList<KeyValuePair<string, string>> files;

        private bool hasParams;

        private string url;

        private string contentType;

        internal CrowdinRequest(string url)
        {
            this.hasParams = false;
            this.body = new List<KeyValuePair<string, object>>();
            this.files = new List<KeyValuePair<string, string>>();

            var urlParam = url.Split(new[] { '?' });
            var param = string.Join("?", urlParam.Skip(1)).Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            this.url = urlParam[0];

            foreach (var kvp in param.Select(s => s.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)))
            {
                this.Parameter(kvp[0], kvp[1]);
            }
        }

        public ICrowdinRequest Placeholder(string placeholder, object value, bool condition = true)
        {
            if (condition)
            {
                this.url = this.url.Replace(string.Format("{{{0}}}", placeholder), value.ToString());
            }

            return this;
        }

        public ICrowdinRequest Parameter(string parameter, object value, bool condition = true)
        {
            if (condition)
            {
                var prefix = this.hasParams ? '&' : '?';

                var ienum = value as IEnumerable;

                if (value.GetType() != typeof(string) && ienum != null)
                {
                    foreach (var c in ienum)
                    {
                        this.url += string.Format("{0}{1}[]={2}", prefix, parameter, c);
                    }
                }
                else
                {
                    this.url += string.Format("{0}{1}={2}", prefix, parameter, value);
                }

                this.hasParams = true;
            }

            return this;
        }

        public ICrowdinRequest Body(string key, object value, bool condition = true)
        {
            if (condition)
            {
                this.body.Add(new KeyValuePair<string, object>(key, value));
            }

            return this;
        }

        public ICrowdinRequest BodyNotNull(string key, object value)
        {
            if (value != null)
            {
                this.body.Add(new KeyValuePair<string, object>(key, value));
            }

            return this;
        }

        public ICrowdinRequest Files(string name, string path, bool condition = true)
        {
            if (condition)
            {
                this.files.Add(new KeyValuePair<string, string>(name, Path.GetFullPath(path)));
            }

            return this;
        }
        
        public ICrowdinResponse Get()
        {
            var response = this.Send("GET");
            return response;
        }

        public ICrowdinResponse Post()
        {
            var data = this.GenerateBody();
            var response = this.Send("POST", data);
            return response;
        }

        public ICrowdinResponse Put()
        {
            var data = this.GenerateBody();
            var response = this.Send("PUT", data);
            return response;
        }

        public ICrowdinResponse Delete()
        {
            var response = this.Send("DELETE");
            return response;
        }

        private byte[] GenerateBody()
        {
            return this.GenerateFileBody();
        }

        private byte[] GenerateJsonBody()
        {
            this.contentType = "application/json";
            var sb = new StringBuilder();
            sb.Append("{");
            var notFirst = false;

            foreach (var keyValuePair in this.body)
            {
                var ienum = keyValuePair.Value as IEnumerable;

                if (keyValuePair.Value.GetType() != typeof(string) && ienum != null)
                {
                    var innerFirst = true;
                    sb.Append(string.Format("{1}\"{0}\": [", keyValuePair.Key, notFirst ? "," : string.Empty));
                    foreach (var obj in ienum)
                    {
                        if (!innerFirst)
                        {
                            sb.Append(", ");
                        }

                        sb.Append(obj);
                        innerFirst = false;
                    }

                    sb.Append("]");
                }
                else if (keyValuePair.Value.ToString().StartsWith("{") && keyValuePair.Value.ToString().EndsWith("}"))
                {
                    sb.Append(
                        string.Format(
                            "{2}\"{0}\":{1}",
                            keyValuePair.Key,
                            keyValuePair.Value,
                            notFirst ? "," : string.Empty));
                }
                else
                {
                    sb.Append(
                        string.Format(
                            "{2}\"{0}\":\"{1}\"",
                            keyValuePair.Key,
                            keyValuePair.Value,
                            notFirst ? "," : string.Empty));
                }

                notFirst = true;
            }

            sb.Append("}");
            var str = sb.ToString();
            return Encoding.UTF8.GetBytes(str);
        }

        private byte[] GenerateFileBody()
        {
            byte[] result;
            var boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            this.contentType = "multipart/form-data; boundary=" + boundary;

            using (var memoryStream = new MemoryStream())
            {
                var boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                var formdataTemplate = "\r\n--" + boundary
                                       + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
                var formdataArrayTemplate = "\r\n--" + boundary
                                       + "\r\nContent-Disposition: form-data; name=\"{0}[]\";\r\n\r\n{1}";
                const string FileHeaderTemplate =
                    "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";

                foreach (var keyValuePair in this.body)
                {
                    var ienum = keyValuePair.Value as IEnumerable;
                    var b = keyValuePair.Value as bool?;

                    if (keyValuePair.Value.GetType() != typeof(string) && ienum != null)
                    {
                        foreach (var obj in ienum)
                        {
                            var formitem = string.Format(formdataArrayTemplate, keyValuePair.Key, obj);
                            var formitembytes = Encoding.UTF8.GetBytes(formitem);
                            memoryStream.Write(formitembytes, 0, formitembytes.Length);
                        }
                    }
                    else if (b != null)
                    {
                        var formitem = string.Format(formdataArrayTemplate, keyValuePair.Key, b.Value ? 1 : 0);
                        var formitembytes = Encoding.UTF8.GetBytes(formitem);
                        memoryStream.Write(formitembytes, 0, formitembytes.Length);
                    }
                    else
                    {
                        var formitem = string.Format(formdataTemplate, keyValuePair.Key, keyValuePair.Value);
                        var formitembytes = Encoding.UTF8.GetBytes(formitem);
                        memoryStream.Write(formitembytes, 0, formitembytes.Length);
                    }
                }

                memoryStream.Write(boundarybytes, 0, boundarybytes.Length);

                foreach (var keyValuePair in this.files)
                {
                    var header = string.Format(FileHeaderTemplate, keyValuePair.Key, keyValuePair.Value);
                    var headerbytes = Encoding.UTF8.GetBytes(header);
                    memoryStream.Write(headerbytes, 0, headerbytes.Length);

                    using (var fileStream = new FileStream(keyValuePair.Value, FileMode.Open, FileAccess.Read))
                    {
                        var buffer = new byte[1024];
                        int bytesRead;

                        do
                        {
                            bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                            memoryStream.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead != 0);
                    }

                    memoryStream.Write(boundarybytes, 0, boundarybytes.Length);
                }

                result = new byte[memoryStream.Length];

                memoryStream.Seek(0, SeekOrigin.Begin);
                memoryStream.Read(result, 0, result.Length);
            }

            return result;
        }

        private ICrowdinResponse Send(string method, byte[] data = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(this.url);
            request.Accept = "Accept=application/json";
            request.ContentType = this.contentType;
            request.Method = method.ToUpper();

            if (method != "GET" && data != null)
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
            }

            var crowdinResponse = new CrowdinResponse();
            var result = new StringBuilder();

            try
            {
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();

                if (responseStream != null)
                {
                    using (var responseReader = new StreamReader(responseStream))
                    {
                        while (!responseReader.EndOfStream)
                        {
                            var line = responseReader.ReadLine();
                            if (line != null)
                            {
                                result.Append(line);
                                result.Append('\n');
                            }
                        }
                    }
                }

                this.GetResponseStatus(crowdinResponse, response);
            }
            catch (WebException ex)
            {
                var stream = ex.Response.GetResponseStream();
                if (stream == null)
                {
                    throw;
                }

                using (var responseReader = new StreamReader(stream))
                {
                    while (!responseReader.EndOfStream)
                    {
                        var line = responseReader.ReadLine();
                        if (line != null)
                        {
                            result.Append(line);
                        }
                    }
                }

                this.GetResponseStatus(crowdinResponse, ex.Response);
            }

            crowdinResponse.Content = result.ToString();

            return crowdinResponse;
        }

        private void GetResponseStatus(CrowdinResponse crowdinResponse, WebResponse response)
        {
            var httpResponse = (HttpWebResponse)response;
            if (httpResponse != null)
            {
                crowdinResponse.StatusCode = (int)httpResponse.StatusCode;
                crowdinResponse.StatusDescription = httpResponse.StatusDescription;
            }
        }
    }
}