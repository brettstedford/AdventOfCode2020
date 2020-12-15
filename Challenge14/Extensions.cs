using System;
using System.Linq;

namespace Challenge14
{
    public static class Extensions
    {
        public static string ToBinaryString(this int[] bitArray)
        {
            var chars = bitArray.Select(b => Convert.ToChar(b.ToString())).ToArray();
            return new string(chars);
        }

        public static string ToBinaryString(this int decimalValue, int padding)
        {
            return Convert.ToString(decimalValue, 2).PadLeft(padding,'0');
        }

        public static int[] ToBinaryArray(this string binaryString)
        {
            return binaryString.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
        }

        public static long ToDecimal(this int[] binaryArray)
        {
            return Convert.ToInt64(binaryArray.ToBinaryString(), 2);
        }
        
        public static int[] ApplyMask(this int[] value, char[] mask)
        {
            var maskedValue = new int[value.Length];

            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'X')
                {
                    maskedValue[i] = value[i];
                    continue;
                }

                maskedValue[i] = int.Parse(mask[i].ToString());
            }
            
            return maskedValue;
        }
    }
}