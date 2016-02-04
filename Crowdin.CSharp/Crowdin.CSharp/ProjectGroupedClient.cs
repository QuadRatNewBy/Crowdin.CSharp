namespace Crowdin.CSharp
{
    internal class ProjectGroupedClient : IProjectGroupedClient
    {
        private IProjectEndpoint project;

        private IDirectoryEndpoint directory;

        public ProjectGroupedClient(ICrowdinHelper helper)
        {
            this.project = new ProjectEndpoint(helper);
            this.directory = new DirectoryEndpoint(helper);
        }

        public IProjectEndpoint Project
        {
            get
            {
                return this.project;
            }
        }

        public IDirectoryEndpoint Directory
        {
            get
            {
                return this.directory;
            }
        }
    }
}