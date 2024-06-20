using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Aura.LonelySatan.Cards
{
    public class Cvv : ValueObject
    {
        public string Value { get; }

        public Cvv() { }
        public Cvv(string cvv)
        {
            if (cvv.Length != 3)
                throw new ArgumentException("Cvv must be 3 characters", nameof(cvv));
            Value = cvv;
        }

        public override bool Equals(object obj)
        {
            return obj is Cvv other && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
