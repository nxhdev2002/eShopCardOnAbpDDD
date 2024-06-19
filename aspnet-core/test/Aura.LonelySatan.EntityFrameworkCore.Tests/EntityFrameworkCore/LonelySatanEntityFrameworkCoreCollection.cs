using Xunit;

namespace Aura.LonelySatan.EntityFrameworkCore;

[CollectionDefinition(LonelySatanTestConsts.CollectionDefinitionName)]
public class LonelySatanEntityFrameworkCoreCollection : ICollectionFixture<LonelySatanEntityFrameworkCoreFixture>
{

}
