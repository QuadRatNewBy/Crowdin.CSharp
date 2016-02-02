namespace Crowdin.CSharp
{
    internal class AccountClient : IAccountClient
    {
        private const string AccountProjectsAddress = "https://api.crowdin.com/api/account/get-projects?account-key={account-key}&login={crowdin username}";
    
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
            string source_language,
            string[] languages,
            string join_policy,
            string language_access_policy = null,
            bool? hide_duplicates = null,
            bool? export_translated_only = null,
            bool? export_approved_only = null,
            bool? auto_translate_dialects = null,
            bool? public_downloads = null,
            bool? use_global_tm = null,
            string logo = null,
            string cname = null,
            string description = null,
            bool? in_context = null,
            string pseudo_language = null,
            string webhook_file_translated = null,
            string webhook_file_proofread = null,
            string webhook_project_translated = null,
            string webhook_project_proofread = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            throw new System.NotImplementedException();
        }
    }
}