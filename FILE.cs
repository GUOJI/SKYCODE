using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyCode
{
    [Serializable]
    public class FILE
    {
        public byte[] data { get { return _data; } }
        public string name { get { return _name; } }

        private byte[] _data;
        private string _name;

        public FILE(string n, byte[] d)
        {
            _data = d;
            _name = n;

        }
        public FILE(string FilePath)
        {
            _name = System.IO.Path.GetFileName(FilePath);
            _data = iByteArray.ReadFileToByteArray(FilePath);

        }
    }
}
