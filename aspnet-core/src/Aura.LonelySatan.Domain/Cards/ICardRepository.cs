using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace Aura.LonelySatan.Cards
{
    public interface ICardRepository : IRepository<Card, Guid>
    {
        Task<Card?> GetCardByUserIdAsync(Guid userId,
            Guid cardId,
            CancellationToken cancellationToken = default);

        Task<List<Card>> GetCardsByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default);

        Task<List<Card>> GetCardAsync(
            ISpecification<Card> spec,
            CancellationToken cancellationToken = default);

        Task<Card> GetByCardNumberAsync(string cardNo,
           CancellationToken cancellationToken = default);


    }
}
