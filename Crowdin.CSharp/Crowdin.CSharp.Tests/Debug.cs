namespace Crowdin.CSharp.Tests
{
    using FluentAssertions;

    using Xunit;

    public class Debug
    {
        [Fact]
        public void Start()
        {
            var ac = CrowdinClient.CreateAccountClient(Settings.UserName, Settings.AccountKey);
            var j = ac.Projects();
            var jp = ac.Projects(CrowdinResponseType.Json);
        }
    }
}