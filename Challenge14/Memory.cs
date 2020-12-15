using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge14
{
    public class Memory
    {
        protected char[] Mask = new char[36];
        protected readonly Dictionary<long, int[]> Addresses = new Dictionary<long, int[]>();

        public Dictionary<long, long> DecimalAddresses
        {
            get
            {
                return Addresses.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToDecimal());
            }
        }

        public void UpdateMask(char[] newMask)
        {
            Mask = newMask;
        }

        public virtual void UpdateAddress(int address, int[] value)
        {
            value = value.ApplyMask(Mask);

            if (!Addresses.TryAdd(address, value))
                Addresses[address] = value;
        }
    }
}