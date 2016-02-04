namespace Crowdin.CSharp
{
    internal class DirectoryEndpoint : IDirectoryEndpoint
    {
        private const string DeleteAddress =
            "https://api.crowdin.com/api/project/{project-identifier}/delete-directory?key={project-key}";

        private const string AddAddress =
            "https://api.crowdin.com/api/project/{project-identifier}/add-directory?key={project-key}";

        private const string ChangeAddress =
            "https://api.crowdin.com/api/project/{project-identifier}/change-directory?key={project-key}";

        private ICrowdinHelper helper;

        public DirectoryEndpoint(ICrowdinHelper helper)
        {
            this.helper = helper;
        }

        public ICrowdinResponse Add(
            string name,
            bool? isBranch = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            var request = this.helper.CreateRequest(AddAddress, type, callback);
            return request.Body("name", name).BodyNotNull("is_branch", isBranch).BodyNotNull("branch", branch).Post();
        }

        public ICrowdinResponse Change(
            string name,
            string newName = null,
            string title = null,
            string exportPattern = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            var request = this.helper.CreateRequest(ChangeAddress, type, callback);
            return
                request.Body("name", name)
                    .BodyNotNull("new_name", newName)
                    .BodyNotNull("title", title)
                    .BodyNotNull("export_pattern", exportPattern)
                    .BodyNotNull("branch", branch)
                    .Post();
        }

        public ICrowdinResponse Delete(
            string name,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            var request = this.helper.CreateRequest(DeleteAddress, type, callback);
            return request.Body("name", name).BodyNotNull("branch", branch).Post();
        }
    }
}