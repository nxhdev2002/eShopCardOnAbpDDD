using Volo.Abp.Modularity;

namespace Aura.LonelySatan;

public abstract class LonelySatanApplicationTestBase<TStartupModule> : LonelySatanTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
