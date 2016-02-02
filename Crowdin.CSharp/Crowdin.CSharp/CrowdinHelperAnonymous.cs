namespace Crowdin.CSharp
{
    internal class CrowdinHelperAnonymous : ICrowdinHelper
    {
        public virtual ICrowdinRequest CreateRequest(string url, CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null)
        {
            var req = new CrowdinRequest(url);

            if (type == CrowdinResponseType.Xml)
            {
                return req;
            }

            var parameter = type == CrowdinResponseType.Json ? "json" : "jsonp";
            var value = callback ?? "f";

            return req.Parameter(parameter, value);
        }
    }
}