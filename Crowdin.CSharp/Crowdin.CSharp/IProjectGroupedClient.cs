namespace Crowdin.CSharp
{
    public interface IProjectGroupedClient
    {
        IProjectEndpoint Project { get; }

        IDirectoryEndpoint Directory { get; }
    }
}