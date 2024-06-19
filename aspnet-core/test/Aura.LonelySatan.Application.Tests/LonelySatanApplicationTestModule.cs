using Volo.Abp.Modularity;

namespace Aura.LonelySatan;

[DependsOn(
    typeof(LonelySatanApplicationModule),
    typeof(LonelySatanDomainTestModule)
)]
public class LonelySatanApplicationTestModule : AbpModule
{

}
