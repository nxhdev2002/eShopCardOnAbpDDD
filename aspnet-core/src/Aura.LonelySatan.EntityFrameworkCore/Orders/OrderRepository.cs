using Aura.LonelySatan.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace Aura.LonelySatan.Orders
{
    public class OrderRepository : EfCoreRepository<LonelySatanDbContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<LonelySatanDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Order> GetByOrderNoAsync(int orderNo, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetQueryableAsync();
            return await dbSet
                .IncludeDetails(includeDetails)
                .FirstOrDefaultAsync(
                    q => q.OrderNo == orderNo,
                    cancellationToken: GetCancellationToken(cancellationToken))
                ?? throw new EntityNotFoundException(typeof(Order));
        }

        public async Task<List<Order>> GetOrdersAsync(ISpecification<Order> spec, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .Where(spec.ToExpression())
            .OrderByDescending(o => o.CreationTime)
            .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Order>> GetOrdersByUserId(Guid userId, ISpecification<Order> spec, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .Where(q => q.Customer.Id == userId)
            .Where(spec.ToExpression())
            .OrderByDescending(o => o.CreationTime)
            .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public override async Task<IQueryable<Order>> WithDetailsAsync()
        {
            return (await GetQueryableAsync())
                .IncludeDetails();
        }
    }
}
