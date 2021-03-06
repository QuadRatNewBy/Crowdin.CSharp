﻿namespace Crowdin.CSharp
{
    using System.Collections.Generic;

    public interface IProjectClient
    {
        IProjectGroupedClient Grouped { get; }

        ICrowdinResponse DeleteProject(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);

        ICrowdinResponse ProjectDetails(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);

        ICrowdinResponse EditProject(
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


        ICrowdinResponse AddDirectory(
            string name,
            bool? isBranch = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null);

        ICrowdinResponse ChangeDirectory(
            string name,
            string newName = null,
            string title = null,
            string exportPattern = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null);

        ICrowdinResponse DeleteDirectory(
            string name,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null);
    }
}