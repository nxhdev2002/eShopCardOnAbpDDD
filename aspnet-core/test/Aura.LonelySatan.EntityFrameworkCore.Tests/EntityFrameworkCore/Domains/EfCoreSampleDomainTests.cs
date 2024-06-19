using Aura.LonelySatan.Samples;
using Xunit;

namespace Aura.LonelySatan.EntityFrameworkCore.Domains;

[Collection(LonelySatanTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<LonelySatanEntityFrameworkCoreTestModule>
{

}
