namespace Crowdin.CSharp.Tests
{
    using FluentAssertions;

    using Xunit;

    public class Debug
    {
        [Fact]
        public void Start()
        {
            var j = CrowdinClient.Anonymous.SupportedLanguages(CrowdinResponseType.Json);
            var jp = CrowdinClient.Anonymous.SupportedLanguages(CrowdinResponseType.Jsonp);
        }
    }
}