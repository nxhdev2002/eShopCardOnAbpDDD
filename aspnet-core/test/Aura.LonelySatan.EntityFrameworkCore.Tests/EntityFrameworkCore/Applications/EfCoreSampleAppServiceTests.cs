using Aura.LonelySatan.Samples;
using Xunit;

namespace Aura.LonelySatan.EntityFrameworkCore.Applications;

[Collection(LonelySatanTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<LonelySatanEntityFrameworkCoreTestModule>
{

}
