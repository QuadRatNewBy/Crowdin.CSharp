namespace Crowdin.CSharp
{
    using System.Collections.Generic;

    public interface IProjectEndpoint
    {
        ICrowdinResponse Delete(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);

        ICrowdinResponse Details(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);

        ICrowdinResponse Edit(
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
            string callback = null);
    }
}