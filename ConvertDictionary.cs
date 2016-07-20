using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyCode
{

    class ConvertDictionary
    {


        public static Dictionary<int, string> GetCONVERTDICTIONATY(Dictionary<int,string> Table, string password)
        {
            string[] Codes = Table.Values.ToArray();
            int length = Codes.Count();
            int t = length / 32;
            int[] ShaHash = iByteArray.ByteArrayToIntArray(iByteArray.HexStringToByteArray(SHAHASH.GetShaHashStringXXX(password, t)));
            Array.Sort(ShaHash, Codes);
            return Enumerable.Range(0, length).ToDictionary(i => i, i => Codes[i]);

        }

        public static Dictionary<string, int> GetREVERTDICTIONATY(Dictionary<int, string> Table, string password)
        {
            string[] Codes = Table.Values.ToArray();
            int length = Codes.Count();
            int t = length / 32;
            int[] ShaHash = iByteArray.ByteArrayToIntArray(iByteArray.HexStringToByteArray(SHAHASH.GetShaHashStringXXX(password, t)));
            Array.Sort(ShaHash, Codes);
            return Enumerable.Range(0, 256).ToDictionary(i => Codes[i], i => i);

        }

        



        /// <summary>
        /// example "JACK IS HERE"; 256
        /// </summary>
        /// <param name="password"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Dictionary<int, int> GetCONVERTDICTIONATY(string password, int length)
        {
            int t = length/32;
            int[] a = Enumerable.Range(0, length).ToArray();
            int[] ShaHash = iByteArray.ByteArrayToIntArray(iByteArray.HexStringToByteArray(SHAHASH.GetShaHashStringXXX(password, t)));
            Array.Sort(ShaHash, a);
            return Enumerable.Range(0, length).ToDictionary(i => i, i => a[i]);

        }

        /// <summary>
        /// example "JACK IS HERE"; 256
        /// </summary>
        /// <param name="password"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Dictionary<int, int> GetREVERTDICTIONATY(string password,int length)
        {
            int t = length / 32;
            int[] a = Enumerable.Range(0, length).ToArray();
            int[] ShaHash = iByteArray.ByteArrayToIntArray(iByteArray.HexStringToByteArray(SHAHASH.GetShaHashStringXXX(password, t)));
            Array.Sort(ShaHash, a);
            return Enumerable.Range(0, length).ToDictionary(i => a[i], i => i);

        }



    }
}
