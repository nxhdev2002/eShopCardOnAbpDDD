using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Aura.LonelySatan.Data;

/* This is used if database provider does't define
 * ILonelySatanDbSchemaMigrator implementation.
 */
public class NullLonelySatanDbSchemaMigrator : ILonelySatanDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
