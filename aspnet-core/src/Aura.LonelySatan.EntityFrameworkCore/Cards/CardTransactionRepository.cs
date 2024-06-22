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

namespace Aura.LonelySatan.Cards
{
    public class CardTransactionRepository : EfCoreRepository<LonelySatanDbContext, CardTransaction, Guid>, ICardTransactionRepository
    {
        public CardTransactionRepository(IDbContextProvider<LonelySatanDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<CardTransaction>> GetTransactionByCardId(Guid cardId,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await GetQueryableAsync();
            return await dbSet
                .Where(x => x.CardId == cardId).ToListAsync();
        }
    }
}
