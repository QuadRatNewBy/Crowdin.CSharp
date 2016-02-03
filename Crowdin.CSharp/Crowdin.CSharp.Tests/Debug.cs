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
            var zj = ac.CreateProject("qrnbApiTestZZZ", "qrnbApiTestZZZ_asd", "en", new[] { "be", "pl" }, "open", "open", type: CrowdinResponseType.Xml, logo: "Files/stitcher.png");
            var pl = ac.Projects(CrowdinResponseType.Json);            
        }
    }
}