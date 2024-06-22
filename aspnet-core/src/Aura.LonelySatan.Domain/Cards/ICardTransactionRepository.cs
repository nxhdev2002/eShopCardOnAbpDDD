using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace Aura.LonelySatan.Cards
{
    public interface ICardTransactionRepository : IRepository<CardTransaction, Guid>
    {
        Task<List<CardTransaction>> GetTransactionByCardId(Guid cardId,
            CancellationToken cancellationToken = default);
    }
}
