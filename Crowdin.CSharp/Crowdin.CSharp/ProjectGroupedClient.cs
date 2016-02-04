namespace Crowdin.CSharp
{
    internal class ProjectGroupedClient : IProjectGroupedClient
    {
        private IProjectEndpoint project;

        public ProjectGroupedClient(ICrowdinHelper helper)
        {
            this.project = new ProjectEndpoint(helper);
        }

        public IProjectEndpoint Project
        {
            get
            {
                return this.project;
            }
        }
    }
}