using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.LonelySatan.Cards.Dto
{
    public class CardGetInputDto
    {
        public Guid Id { get; set; }
    }

    public class CardGetDetailsInputDto
    {
        public Guid Id { get; set; }
        public int OTP { get; set; }
    }
}
