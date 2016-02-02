namespace Crowdin.CSharp
{
    public static class CrowdinClient
    {
        private static readonly IAnonymousClient anonymous;

        public static IAnonymousClient Anonymous
        {
            get
            {
                return anonymous;
            }
        }

        static CrowdinClient()
        {
            anonymous = new AnonymousClient(new CrowdinHelperAnonymous());
        }

        public static IAccountClient CreateAccountClient(string userName, string accountKey)
        {
            return new AccountClient(new CrowdinHelperAccount(userName, accountKey));
        }
    }
}