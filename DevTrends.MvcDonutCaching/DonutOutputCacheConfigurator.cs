using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DevTrends.MvcDonutCaching
{
    public interface IDonutOutputCacheConfigurator
    {
        IDonutOutputCacheConfigurator SetKeyBuilder(IKeyBuilder keyBuilder);
        IDonutOutputCacheConfigurator ConfigureDonutHoleFiller(Action<IDonutHoleFillerConfigurator> donutHoleFillerConfigurator);
        IDonutOutputCacheConfigurator ConfigureCachedActionsFilters(Action<IDonutOutputCacheCachedActionsFiltersConfigurator> donutHoleFillerConfigurator);
    }

    public interface IDonutHoleFillerConfigurator
    {
        IDonutHoleFillerConfigurator SetActionSettingsSerialiser(IActionSettingsSerialiser actionSettingsSerialiser);
        IDonutHoleFillerConfigurator SetEncryptor(IEncryptor encryptor);
    }

    public interface IDonutOutputCacheCachedActionsFiltersConfigurator
    {
        IDonutOutputCacheCachedActionsFiltersConfigurator AddCachedActionsFilter(
            Func<ActionExecutingContext, bool> cachedActionsFilter);
    }

    public interface IDonutOutputCacheConfiguration
    {
        IKeyBuilder KeyBuilder { get; }
        IActionSettingsSerialiser ActionSettingsSerialiser { get; }
        IEncryptor Encryptor { get; }
        ICachedActionsFiltersConfiguration CachedActionsFiltersConfiguration { get; }
    }

    public interface ICachedActionsFiltersConfiguration
    {
        IList<Func<ActionExecutingContext, bool>> CachedActionsFilters { get; }
    }

    public class DonutOutputCacheConfiguration : IDonutOutputCacheConfiguration
    {
        public IKeyBuilder KeyBuilder { get; set; }
        public IActionSettingsSerialiser ActionSettingsSerialiser { get; set; }
        public IEncryptor Encryptor { get; set; }
        public ICachedActionsFiltersConfiguration CachedActionsFiltersConfiguration { get; set; }
    }

    public class CachedActionsFiltersConfiguration : ICachedActionsFiltersConfiguration
    {
        public IList<Func<ActionExecutingContext, bool>> CachedActionsFilters { get; set; }

        public CachedActionsFiltersConfiguration()
        {
            CachedActionsFilters = new List<Func<ActionExecutingContext, bool>>();
        }
    }

    public class DonutOutputCacheConfigurator : IDonutOutputCacheConfigurator, IDonutHoleFillerConfigurator, IDonutOutputCacheCachedActionsFiltersConfigurator
    {
        private IKeyBuilder _keyBuilder;
        private IActionSettingsSerialiser _actionSettingsSerialiser;
        private IEncryptor _encryptor;
        private ICachedActionsFiltersConfiguration _cachedActionsFiltersConfiguration;

        public IDonutOutputCacheConfigurator ConfigureDonutHoleFiller(Action<IDonutHoleFillerConfigurator> donutHoleFillerConfigurator)
        {
            if (donutHoleFillerConfigurator != null)
            {
                donutHoleFillerConfigurator(this);
            }
            return this;
        }

        public IDonutOutputCacheConfigurator ConfigureCachedActionsFilters(Action<IDonutOutputCacheCachedActionsFiltersConfigurator> donutHoleFillerConfigurator)
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
                KeyBuilder = _keyBuilder,
                CachedActionsFiltersConfiguration = _cachedActionsFiltersConfiguration
            };
        }

        public IDonutOutputCacheCachedActionsFiltersConfigurator AddCachedActionsFilter(Func<ActionExecutingContext, bool> cachedActionsFilter)
        {
            if (_cachedActionsFiltersConfiguration == null)
            {
                _cachedActionsFiltersConfiguration = new CachedActionsFiltersConfiguration();
            }

            _cachedActionsFiltersConfiguration.CachedActionsFilters.Add(cachedActionsFilter);

            return this;
        }
    }
}
