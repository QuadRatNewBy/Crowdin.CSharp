namespace Crowdin.CSharp
{
    using System.Collections.Generic;

    public interface IAccountClient
    {
        ICrowdinResponse Projects(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);

        ICrowdinResponse CreateProject(
            string name,
            string identifier,
            string sourceLanguage,
            IEnumerable<string> languages,
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
            string callback = null);
    }
}