namespace Crowdin.CSharp
{
    public interface ICrowdinResponse
    {
        int StatusCode { get; }

        string StatusDescription { get; }

        string Content { get; }
    }
}