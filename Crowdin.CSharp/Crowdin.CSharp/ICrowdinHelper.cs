namespace Crowdin.CSharp
{
    internal interface ICrowdinHelper
    {
        ICrowdinRequest CreateRequest(string url, CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null);
    }
}