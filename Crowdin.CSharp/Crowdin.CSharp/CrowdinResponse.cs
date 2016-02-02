namespace Crowdin.CSharp
{
    internal class CrowdinResponse : ICrowdinResponse
    {
        public int StatusCode { get; internal set; }

        public string StatusDescription { get; internal set; }

        public string Content { get; internal set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}\n", this.StatusCode, this.StatusDescription) + this.Content;
        }
    }
}