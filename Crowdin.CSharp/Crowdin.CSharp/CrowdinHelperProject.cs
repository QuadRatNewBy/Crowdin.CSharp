namespace Crowdin.CSharp
{
    internal class CrowdinHelperProject : CrowdinHelperAnonymous
    {
        private const string ProjectIdentifierPlaceholder = "project-identifier";

        private const string ProjectKeyPlaceholder = "project-key";

        private readonly string projectIdentifier;

        private readonly string projectKey;

        public CrowdinHelperProject(string projectIdentifier, string projectKey)
        {
            this.projectIdentifier = projectIdentifier;
            this.projectKey = projectKey;
        }

        public override ICrowdinRequest CreateRequest(
            string url,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            var req =
                base.CreateRequest(url, type, callback)
                    .Placeholder(ProjectIdentifierPlaceholder, this.projectIdentifier)
                    .Placeholder(ProjectKeyPlaceholder, this.projectKey);
            return req;
        }
    }
}