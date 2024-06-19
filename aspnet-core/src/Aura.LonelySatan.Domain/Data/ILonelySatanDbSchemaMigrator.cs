using System.Threading.Tasks;

namespace Aura.LonelySatan.Data;

public interface ILonelySatanDbSchemaMigrator
{
    Task MigrateAsync();
}
