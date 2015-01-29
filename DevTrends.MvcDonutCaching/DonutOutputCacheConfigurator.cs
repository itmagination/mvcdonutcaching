using System;

namespace DevTrends.MvcDonutCaching
{
    public interface IDonutOutputCacheConfigurator
    {
        IDonutOutputCacheConfigurator SetKeyBuilder(IKeyBuilder keyBuilder);
        IDonutOutputCacheConfigurator ConfigureDonutHoleFiller(Action<IDonutHoleFillerConfigurator> donutHoleFillerConfigurator);
    }

    public interface IDonutHoleFillerConfigurator
    {
        IDonutHoleFillerConfigurator SetActionSettingsSerialiser(IActionSettingsSerialiser actionSettingsSerialiser);
        IDonutHoleFillerConfigurator SetEncryptor(IEncryptor encryptor);
    }

    public interface IDonutOutputCacheConfiguration
    {
        IKeyBuilder KeyBuilder { get; }
        IActionSettingsSerialiser ActionSettingsSerialiser { get; }
        IEncryptor Encryptor { get; }
    }

    public class DonutOutputCacheConfiguration : IDonutOutputCacheConfiguration
    {
        public IKeyBuilder KeyBuilder { get; set; }
        public IActionSettingsSerialiser ActionSettingsSerialiser { get; set; }
        public IEncryptor Encryptor { get; set; }
    }

    public class DonutOutputCacheConfigurator : IDonutOutputCacheConfigurator, IDonutHoleFillerConfigurator
    {
        private IKeyBuilder _keyBuilder;
        private IActionSettingsSerialiser _actionSettingsSerialiser;
        private IEncryptor _encryptor;

        public IDonutOutputCacheConfigurator ConfigureDonutHoleFiller(Action<IDonutHoleFillerConfigurator> donutHoleFillerConfigurator)
        {
            if (donutHoleFillerConfigurator != null)
            {
                donutHoleFillerConfigurator(this);
            }
            return this;
        }

        public IDonutOutputCacheConfigurator SetKeyBuilder(IKeyBuilder keyBuilder)
        {
            _keyBuilder = keyBuilder;
            return this;
        }

        public IDonutHoleFillerConfigurator SetActionSettingsSerialiser(IActionSettingsSerialiser actionSettingsSerialiser)
        {
            _actionSettingsSerialiser = actionSettingsSerialiser;
            return this;
        }

        public IDonutHoleFillerConfigurator SetEncryptor(IEncryptor encryptor)
        {
            _encryptor = encryptor;
            return this;
        }

        public IDonutOutputCacheConfiguration CreateDonutOutputCacheConfiguration()
        {
            return new DonutOutputCacheConfiguration
            {
                ActionSettingsSerialiser = _actionSettingsSerialiser,
                Encryptor = _encryptor,
                KeyBuilder = _keyBuilder
            };
        }
    }
}
