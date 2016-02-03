using System;

namespace Crowdin.CSharp
{
    internal interface ICrowdinRequest
    {
        ICrowdinRequest Placeholder(string placeholder, object value, bool condition = true);

        ICrowdinRequest Parameter(string parameter, object value, bool condition = true);

        ICrowdinRequest Body(string key, object value, bool condition = true);

        ICrowdinRequest BodyNotNull(string key, object value);

        ICrowdinRequest Files(string name, string path, bool condition = true);

        ICrowdinResponse Get();

        ICrowdinResponse Post();

        ICrowdinResponse Put();

        ICrowdinResponse Delete();
    }
}