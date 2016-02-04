namespace Crowdin.CSharp.Tests
{
    using FluentAssertions;

    using Xunit;

    public class Debug
    {
        [Fact]
        public void Start()
        {
            var pc = CrowdinClient.CreateProjectClient(Settings.ProjectIdentifier, Settings.ProjectKey);
            var info = pc.ProjectDetails(CrowdinResponseType.Json);
            var edit = pc.EditProject(logo: "Files/stitcher.png", type: CrowdinResponseType.Json);
            var delete = pc.DeleteProject(CrowdinResponseType.Json);
        }
    }
}