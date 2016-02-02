namespace Crowdin.CSharp
{
    internal sealed class CrowdinHelperAccount : CrowdinHelperAnonymous
    {
        private const string UserNamePlacaholder = "crowdin username";

        private const string AccountKeyPlacaholder = "account-key";

        private readonly string userName;

        private readonly string accountKey;

        public CrowdinHelperAccount(string userName, string accountKey)
        {
            this.userName = userName;
            this.accountKey = accountKey;
        }

        public override ICrowdinRequest CreateRequest(
            string url,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null)
        {
            var req = base.CreateRequest(url, type, callback).Placeholder(UserNamePlacaholder, this.userName)
                .Placeholder(AccountKeyPlacaholder, this.accountKey);
            return req;
        }
    }
}