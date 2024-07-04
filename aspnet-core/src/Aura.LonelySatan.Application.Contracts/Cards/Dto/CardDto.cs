using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardDto : AuditedEntityDto<Guid>
    {
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public CardStatus Status { get; set; }
    }

    public class CardDetailsDto: CardDto
    {
        public DateTime Exp { get; set; }
        public string Cvv { get; set; }
    }
}
