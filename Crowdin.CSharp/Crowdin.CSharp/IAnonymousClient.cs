namespace Crowdin.CSharp
{
    public interface IAnonymousClient
    {
        ICrowdinResponse SupportedLanguages(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);
    }
}