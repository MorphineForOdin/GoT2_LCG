using System.Collections.Generic;

namespace GotLcg.Config
{
    public interface IConfigSection
    {   
        bool Exists { get; }

        string Name { get; }

        IDictionary<string, string> Settings { get; }
    }
}