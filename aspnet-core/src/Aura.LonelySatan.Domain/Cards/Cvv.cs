using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Aura.LonelySatan.Cards
{
    public class Cvv : ValueObject
    {
        public string Value { get; }

        private Cvv() { }
        public Cvv(string cvv)
        {
            if (cvv.Length != 3)
                throw new ArgumentException("Cvv must be 3 characters", nameof(cvv));
            Value = cvv;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

    }
}
