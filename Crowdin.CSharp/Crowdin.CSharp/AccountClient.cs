namespace Crowdin.CSharp
{
    internal class AccountClient : IAccountClient
    {
        private const string AccountProjectsAddress = "https://api.crowdin.com/api/account/get-projects?account-key={account-key}&login={crowdin username}";

        private const string CreateProjectAddress = "https://api.crowdin.com/api/account/create-project?account-key={account-key}&login={crowdin username}";

        private ICrowdinHelper helper;

        public AccountClient(ICrowdinHelper helper)
        {
            this.helper = helper;
        }

        public ICrowdinResponse Projects(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null)
        {
            var request = this.helper.CreateRequest(AccountProjectsAddress, type, callback);
            return request.Post();
        }

        public ICrowdinResponse CreateProject(
            string name,
            string identifier,
            string sourceLanguage,
            string[] languages,
            string joinPolicy,
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
            bool? inContext = null,
            string pseudoLanguage = null,
            string webhookFileTranslated = null,
            string webhookFileProofread = null,
            string webhookProjectTranslated = null,
            string webhookProjectProofread = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            var request = this.helper.CreateRequest(CreateProjectAddress, type, callback);
            return request
                .Body("name", name)
                .Body("identifier", identifier)
                .Body("source_language", sourceLanguage)
                .Body("languages", languages)
                .Body("join_policy", joinPolicy)
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
                .BodyNotNull("in_context", inContext)
                .BodyNotNull("pseudo_language", pseudoLanguage)
                .BodyNotNull("webhook_file_translated", webhookFileTranslated)
                .BodyNotNull("webhook_file_proofread", webhookFileProofread)
                .BodyNotNull("webhook_project_translated", webhookProjectTranslated)
                .BodyNotNull("webhook_project_proofread", webhookProjectProofread)
                .Post();
        }        
    }
}