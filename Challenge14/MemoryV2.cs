using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge14
{
    public class MemoryV2 : Memory
    {
        public override void UpdateAddress(int address, int[] value)
        {
            // get address as binary
            var binaryAddressArray = address
                .ToBinaryString(36)
                .ToBinaryArray();

            // apply mask to binary address
            var addresses = MirrorAddresses(binaryAddressArray).ToList();

            addresses.ForEach(a =>
            {
                var mirroredAddress = a.ToDecimal();
                Addresses[mirroredAddress] = value;
            });
        }

        private IEnumerable<int[]> MirrorAddresses(int[] address)
        {
            // get x's in current mask
            var nX = Mask.Count(c => c == 'X');

            var combinations = GetNthEnumeration(new[] {"0", "1"}, nX-1);

            foreach (var combination in combinations)
            {
                var mirroredAddress = (int[])address.Clone();
                var cI = 0;

                for (var i = 0; i < Mask.Length; i++)
                {
                    if (Mask[i] == '1')
                    {
                        mirroredAddress[i] = 1;
                    }

                    if (Mask[i] == 'X')
                    {
                        mirroredAddress[i] = int.Parse(combination[cI].ToString());
                        cI++;
                    }
                }

                yield return mirroredAddress;
            }
        }

        private static IEnumerable<string> GetNthEnumeration(IEnumerable<string> baseEnumeration, int n)
        {
            if (baseEnumeration == null) throw new ArgumentNullException();

            if (n < 0) throw new ArgumentOutOfRangeException();

            if (n == 0)
            {
                foreach (var item in baseEnumeration)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var pre in baseEnumeration)
                {
                    foreach (var post in GetNthEnumeration(baseEnumeration, n - 1))
                    {
                        yield return pre + post;
                    }
                }
            }
        }
    }
}