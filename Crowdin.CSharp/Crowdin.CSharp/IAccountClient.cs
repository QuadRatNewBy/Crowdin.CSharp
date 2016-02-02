﻿namespace Crowdin.CSharp
{
    public interface IAccountClient
    {
        ICrowdinResponse Projects(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);

        ICrowdinResponse CreateProject(
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
            string callback = null);
    }
}