namespace Crowdin.CSharp
{
    internal class AnonymousClient : IAnonymousClient
    {
        private const string SupportedLanguageAddress = "https://api.crowdin.com/api/supported-languages";

        private ICrowdinHelper helper;

        public AnonymousClient(ICrowdinHelper helper)
        {
            this.helper = helper;
        }

        public ICrowdinResponse SupportedLanguages(CrowdinResponseType type = CrowdinResponseType.Xml, string callback = null)
        {
            var request = this.helper.CreateRequest(SupportedLanguageAddress, type, callback);
            return request.Get();
        }
    }
}