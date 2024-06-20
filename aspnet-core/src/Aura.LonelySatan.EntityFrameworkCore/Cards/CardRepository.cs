using Aura.LonelySatan.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace Aura.LonelySatan.Cards
{
    internal class CardRepository : EfCoreRepository<LonelySatanDbContext, Card, Guid>, ICardRepository
    {
        public CardRepository(IDbContextProvider<LonelySatanDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Card> GetByCardNumberAsync(string cardNo, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetQueryableAsync();
            return await dbSet
                .FirstOrDefaultAsync(x => x.CardNumber == cardNo, cancellationToken: GetCancellationToken(cancellationToken))
                ?? throw new EntityNotFoundException(typeof(Card));
        }

        public async Task<List<Card>> GetCardAsync(ISpecification<Card> spec, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetQueryableAsync();
            return await dbSet
                .Where(spec.ToExpression())
                .OrderByDescending(o => o.CreationTime)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Card>> GetCardsByUserIdAsync(Guid userId, ISpecification<Card> spec, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(q => q.CreatorId == userId)
                .Where(spec.ToExpression())
                .OrderByDescending(o => o.CreationTime)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
