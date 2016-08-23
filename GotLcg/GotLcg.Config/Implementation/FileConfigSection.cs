using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace GotLcg.Config.Implementation
{
    public class FileConfigSection : IConfigSection
    {
        private readonly Lazy<NameValueCollection> _lazyCollection;

        public FileConfigSection(string name)
        {
            Name = name;
            _lazyCollection = new Lazy<NameValueCollection>(
                () => ConfigurationManager.GetSection(Name) as NameValueCollection
            );
        }

        public bool Exists => _lazyCollection.Value != null;

        public string Name { get; }

        public IDictionary<string, string> Settings
        {
            get
            {
                if (!Exists)
                {
                    throw new ConfigurationErrorsException($"Could not locate section with name '{Name}' in app/web configuration file");
                }

                var settings = new Dictionary<string, string>(_lazyCollection.Value.AllKeys.Length);

                foreach (string key in _lazyCollection.Value.AllKeys)
                {
                    settings.Add(key,_lazyCollection.Value[key]);
                }

                return settings;
            }
        }
    }
}
