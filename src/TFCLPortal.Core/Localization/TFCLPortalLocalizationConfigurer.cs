using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TFCLPortal.Localization
{
    public static class TFCLPortalLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TFCLPortalConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TFCLPortalLocalizationConfigurer).GetAssembly(),
                        "TFCLPortal.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
