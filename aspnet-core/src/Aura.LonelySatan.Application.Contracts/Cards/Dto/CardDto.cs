﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardDto : EntityDto<Guid>
    {
        public string CardNumber { get; set; }
        public DateTime ExpDate { get; set; }
        public string Cvv { get; set; }
        public decimal Balance { get; set; }
        public CardStatus Status { get; set; }
    }
}
