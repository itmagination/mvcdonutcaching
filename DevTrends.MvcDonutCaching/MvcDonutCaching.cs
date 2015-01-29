using System;

namespace DevTrends.MvcDonutCaching
{
    public static class MvcDonutCaching
    {
        private static IDonutOutputCacheConfiguration _configuration;

        private static readonly IKeyBuilder DefaultKeyBuilder = new KeyBuilder();
        private static readonly IEncryptor DefaultEncryptor = new Encryptor();
        private static readonly IActionSettingsSerialiser DefaultActionSettingsSerialiser = new ActionSettingsSerialiser();
        private static readonly IActionSettingsSerialiser DefaultEncryptingActionSettingsSerialiser =
            new EncryptingActionSettingsSerialiser(ActionSettingsSerialiser, Encryptor);
        private static readonly ICachedActionsFiltersConfiguration DefaultCachedActionsFiltersConfiguration =
            new CachedActionsFiltersConfiguration();

        private static IActionSettingsSerialiser _encryptingActionSettingsSerialiser;

        public static IKeyBuilder KeyBuilder
        {
            get
            {
                if (_configuration != null && _configuration.KeyBuilder != null)
                {
                    return _configuration.KeyBuilder;
                }

                return DefaultKeyBuilder;
            }
        }

        public static IEncryptor Encryptor
        {
            get
            {
                if (_configuration != null && _configuration.Encryptor != null)
                {
                    return _configuration.Encryptor;
                }

                return DefaultEncryptor;
            }
        }

        public static IActionSettingsSerialiser EncryptingActionSettingsSerialiser
        {
            get
            {
                if (_encryptingActionSettingsSerialiser != null)
                {
                    return _encryptingActionSettingsSerialiser;
                }

                return DefaultEncryptingActionSettingsSerialiser;
            }
        }

        public static IActionSettingsSerialiser ActionSettingsSerialiser
        {
            get
            {
                if (_configuration != null && _configuration.ActionSettingsSerialiser != null)
                {
                    return _configuration.ActionSettingsSerialiser;
                }

                return DefaultActionSettingsSerialiser;
            }
        }

        public static ICachedActionsFiltersConfiguration CachedActionsFiltersConfiguration
        {
            get
            {
                if (_configuration != null && _configuration.CachedActionsFiltersConfiguration != null)
                {
                    return _configuration.CachedActionsFiltersConfiguration;
                }
                return DefaultCachedActionsFiltersConfiguration;
            }
        }

        public static void Configure(Action<IDonutOutputCacheConfigurator> donutOutputCacheConfigurator)
        {
            if (donutOutputCacheConfigurator != null)
            {
                var configurator = new DonutOutputCacheConfigurator();
                donutOutputCacheConfigurator(configurator);
                _configuration = configurator.CreateDonutOutputCacheConfiguration();

                _encryptingActionSettingsSerialiser = new EncryptingActionSettingsSerialiser(ActionSettingsSerialiser,
                                                                                            Encryptor);
            }

        }
    }
}
