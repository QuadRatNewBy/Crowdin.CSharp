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
            var add = pc.AddDirectory("TestDir", type: CrowdinResponseType.Json);
            var change = pc.ChangeDirectory("TestDir", "TestDirZ", "ImNotDir", type: CrowdinResponseType.Json);
            var delete = pc.DeleteDirectory("TestDirZ", type: CrowdinResponseType.Json);
        }
    }
}