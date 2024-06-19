using Volo.Abp.Modularity;

namespace Aura.LonelySatan;

/* Inherit from this class for your domain layer tests. */
public abstract class LonelySatanDomainTestBase<TStartupModule> : LonelySatanTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
