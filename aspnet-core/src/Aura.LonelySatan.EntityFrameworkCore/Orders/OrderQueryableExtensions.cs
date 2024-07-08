using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aura.LonelySatan.Orders
{
    public static class OrderQueryableExtensions
    {
        public static IQueryable<Order> IncludeDetails(this IQueryable<Order> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Address)
                .Include(x => x.Customer);
        }
    }
}
