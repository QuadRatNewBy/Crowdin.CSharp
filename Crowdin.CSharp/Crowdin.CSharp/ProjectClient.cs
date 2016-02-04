namespace Crowdin.CSharp
{
    using System.Collections.Generic;

    internal class ProjectClient : IProjectClient
    {
        private IProjectGroupedClient groupedClient;

        public ProjectClient(IProjectGroupedClient groupedClient)
        {
            this.groupedClient = groupedClient;
        }

        public IProjectGroupedClient Grouped
        {
            get
            {
                return this.groupedClient;
            }
        }

        public ICrowdinResponse DeleteProject(
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            return this.groupedClient.Project.Delete(type, callback);
        }

        public ICrowdinResponse ProjectDetails(
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            return this.groupedClient.Project.Details(type, callback);
        }

        public ICrowdinResponse EditProject(
            string name = null,
            IEnumerable<string> languages = null,
            string joinPolicy = null,
            string languageAccessPolicy = null,
            bool? hideDuplicates = null,
            bool? exportTranslatedOnly = null,
            bool? exportApprovedOnly = null,
            bool? autoTranslateDialects = null,
            bool? publicDownloads = null,
            bool? useGlobalTm = null,
            string logo = null,
            string cname = null,
            string description = null,
            string webhookFileTranslated = null,
            string webhookFileProofread = null,
            string webhookProjectTranslated = null,
            string webhookProjectProofread = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            return this.groupedClient.Project.Edit(
                name,
                languages,
                joinPolicy,
                languageAccessPolicy,
                hideDuplicates,
                exportTranslatedOnly,
                exportApprovedOnly,
                autoTranslateDialects,
                publicDownloads,
                useGlobalTm,
                logo,
                cname,
                description,
                webhookFileTranslated,
                webhookFileProofread,
                webhookProjectTranslated,
                webhookProjectProofread,
                type,
                callback);
        }

        public ICrowdinResponse AddDirectory(
            string name,
            bool? isBranch = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            return this.Grouped.Directory.Add(name, isBranch, branch, type, callback);
        }

        public ICrowdinResponse ChangeDirectory(
            string name,
            string newName = null,
            string title = null,
            string exportPattern = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            return this.Grouped.Directory.Change(name, newName, title, exportPattern, branch, type, callback);
        }

        public ICrowdinResponse DeleteDirectory(
            string name,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            return this.Grouped.Directory.Delete(name, branch, type, callback);
        }
    }
}