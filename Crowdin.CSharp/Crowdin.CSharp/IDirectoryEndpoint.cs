namespace Crowdin.CSharp
{
    public interface IDirectoryEndpoint
    {
        ICrowdinResponse Add(
            string name,
            bool? isBranch = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null);

        ICrowdinResponse Change(
            string name,
            string newName = null,
            string title = null,
            string exportPattern = null,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null);

        ICrowdinResponse Delete(
            string name,
            string branch = null,
            CrowdinResponseType type = CrowdinResponseType.Xml,
            string callback = null);
    }
}