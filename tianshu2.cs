using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyCode
{
    public class Tianshu222222222222222
    {



        public static List<string> ByteArrayToi4096CodeList(byte[] bytes)
        {
            string hex = iByteArray.ByteArrayToHexString(bytes);

            List<string> CL = new List<string>();

            for (int i = 0; i < hex.Length; i += 3)
            {
                int Rindex = i;
                int Gindex = i + 1;
                int Bindex = i + 2;
                char R;
                char G;
                char B;
                if (Gindex > hex.Length - 1)
                {
                    R = hex[Rindex];
                    // CL.Add(new string(new char[] { R }));
                    G = '0';
                    B = '0';
                }
                else if (Bindex > hex.Length - 1)
                {
                    R = hex[Rindex];
                    G = hex[Gindex];
                    // CL.Add(new string(new char[] { R, G }));
                    B = '0';
                }
                else
                {
                    R = hex[Rindex];
                    G = hex[Gindex];
                    B = hex[Bindex];
                    // CL.Add(new string(new char[] { R, G, B }));
                }

                CL.Add(new string(new char[] { R, G, B }));
            }
            return CL;
        }

        public static byte[] i4096CodeListToByteArray(List<string> i4096)
        {
            string IA = "";

            foreach (string xxa in i4096)
            {
                IA += xxa;
            }
            return iByteArray.HexStringToByteArray(IA);
            //return IA;
        }



        public static string i4096ENCODE(byte[] data)
        {
            Dictionary<int, string> sha4096a = ConvertDictionary.GetCONVERTDICTIONATY(Tianshu.CodeMap.HanziCode4096, "jack is here");
            List<string> i1 = ByteArrayToi4096CodeList(data);
            string answer = "";
            foreach (string hex in i1)
            {
                int index = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                answer += sha4096a[index];
            }
            //// Store integer 182
            //int intValue = 182;
            //// Convert integer 182 as a hex in a string variable
            //string hexValue = intValue.ToString("X");
            //// Convert the hex string back to the number
            //int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            return answer;
        }

        public static byte[] i4096DECODE(string i4096code)
        {
            string a2 = "";
            Dictionary<string, int> sha4096b = ConvertDictionary.GetREVERTDICTIONATY(Tianshu.CodeMap.HanziCode4096, "jack is here");
            foreach (char a in i4096code)
            {
                int index = sha4096b[a.ToString()];
                a2 += index.ToString("X");

            }

            return iByteArray.HexStringToByteArray(a2);
        }




    }
}
