﻿using System;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardDto : AuditedEntityDto<Guid>
    {
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public CardStatus Status { get; set; }
    }

    public class CardDetailsDto : CardDto
    {
        public DateTime ExpDate { get; set; }
        public string Cvv { get; set; }
    }
}
