using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyCode
{
    class SHAHASH
    {
        public static byte[] GetHashBytesXXX(string Password,int t)
        {
            return null;
        }

        public static string GetShaHashStringXXX(string Password, int t)
        {
            List<string> codes = new List<string>();


            string current = Password;
            string next = string.Empty;
            string R = string.Empty;
            for (int i = 0; i <= t; i++)
            {
                codes.Add(next);
                next = getHashString(current);
                current = next;
            }
            foreach (string code in codes) { R += code; }
            //Parallel.ForEach(codes, (code) => { R += code; });
            return R;
        }

        private static byte[] getHashBytes(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            using (System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed())
            {
                return hashstring.ComputeHash(bytes);
            }
        }
        private static string getHashString(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            using (System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] hash = hashstring.ComputeHash(bytes);
                string hashString = string.Empty;
                foreach (byte x in hash) { hashString += String.Format("{0:x2}", x); }
                //Parallel.ForEach(hash, (x) => { hashString += String.Format("{0:x2}", x); });
                return hashString;
            }
        }

    }
    
}
