namespace Crowdin.CSharp
{
    using System.Collections.Generic;

    internal class ProjectEndpoint : IProjectEndpoint
    {
        private const string DeleteAddress =
            "https://api.crowdin.com/api/project/{project-identifier}/delete-project?key={project-key}";

        private const string EditAddress =
            "https://api.crowdin.com/api/project/{project-identifier}/edit-project?key={project-key}";

        private const string DetailsAddress =
            "https://api.crowdin.com/api/project/{project-identifier}/info?key={project-key}";

        private ICrowdinHelper helper;

        public ProjectEndpoint(ICrowdinHelper helper)
        {
            this.helper = helper;
        }

        public ICrowdinResponse Delete(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null)
        {
            var request = this.helper.CreateRequest(DeleteAddress, type, callback);
            return request.Get();
        }

        public ICrowdinResponse Details(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null)
        {
            var request = this.helper.CreateRequest(DetailsAddress, type, callback);
            return request.Post();
        }

        public ICrowdinResponse Edit(
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
            var request = this.helper.CreateRequest(EditAddress, type, callback);
            return
                request.BodyNotNull("name", name)
                    .BodyNotNull("languages", languages)
                    .BodyNotNull("join_policy", joinPolicy)
                    .BodyNotNull("language_access_policy", languageAccessPolicy)
                    .BodyNotNull("hide_duplicates", hideDuplicates)
                    .BodyNotNull("export_translated_only", exportTranslatedOnly)
                    .BodyNotNull("export_approved_only", exportApprovedOnly)
                    .BodyNotNull("auto_translate_dialects", autoTranslateDialects)
                    .BodyNotNull("public_downloads", publicDownloads)
                    .BodyNotNull("use_global_tm", useGlobalTm)
                    .Files("logo", logo, logo != null)
                    .BodyNotNull("cname", cname)
                    .BodyNotNull("description", description)
                    .BodyNotNull("webhook_file_translated", webhookFileTranslated)
                    .BodyNotNull("webhook_file_proofread", webhookFileProofread)
                    .BodyNotNull("webhook_project_translated", webhookProjectTranslated)
                    .BodyNotNull("webhook_project_proofread", webhookProjectProofread)
                    .Post();
        }
    }
}