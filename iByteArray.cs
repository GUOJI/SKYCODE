using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Drawing;


namespace SkyCode
{
    public class iByteArray
    {




        public static byte[] BitmapToByteArray(Bitmap img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        public static Bitmap ByteArrayToBitmap(byte[] array)
        {
            MemoryStream stream = new MemoryStream(array);
            return new Bitmap(stream);

        }
        //
        //about file and output

        //write file to folder
        public static void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file
            //HttpPostedFile myFile = FileUpload1.PostedFile;
            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file
            newFile.Close();
        }

        public static void WriteToTxt(string path, string input)
        {
            System.IO.File.WriteAllText(path, input);
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public static Byte[] CompressDataSet(DataSet dataset)
        {
            Byte[] data;
            MemoryStream mem = new MemoryStream();
            GZipStream zip = new GZipStream(mem, CompressionMode.Compress);
            dataset.WriteXml(zip, XmlWriteMode.WriteSchema);
            zip.Close();
            data = mem.ToArray();
            mem.Close();
            return data;
        }
        public static DataSet DecompressDataSet(Byte[] data)
        {
            MemoryStream mem = new MemoryStream(data);
            GZipStream zip = new GZipStream(mem, CompressionMode.Decompress);
            DataSet dataset = new DataSet();
            dataset.ReadXml(zip, XmlReadMode.ReadSchema);
            zip.Close();
            mem.Close();
            return dataset;
        }




        public static byte[] Compressbytes(byte[] bytes)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    gzip.Write(bytes, 0, bytes.Length);
                }
                return memory.ToArray();
            }
        }
        public static byte[] Decompressbytes(byte[] zipbytes)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(zipbytes), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }



        public static byte[] StringTextToBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string BytesToStringText(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static byte[] ReadFileToByteArray(string filepath)
        {
            return System.IO.File.ReadAllBytes(filepath);
        }

        public static string ReadTxtToString(string filepath)
        {
            StreamReader sr = new StreamReader(filepath);//, Encoding.GetEncoding("gb2312"));
            string result = sr.ReadToEnd();
            sr.Close();
            return result;

        }

        public static string ByteArrayToBase64String(byte[] ba)
        {
            return Convert.ToBase64String(ba);
        }

        public static byte[] Base64StringToByteArray(string Base64)
        {
            return Encoding.UTF8.GetBytes(Base64);
        }

        public static string[] ByteArrayToBase64StringArray(byte[] ba)
        {
            string a= Convert.ToBase64String(ba);
            int NumberChars = a.Length;
            string[] bytes = new string[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = a.Substring(i, 2);
            return bytes;
        }


//public static byte[] Base


        public static string ByteArrayToHexString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        public static string[] ByteArrayToHexStringArray(byte[] ba)
        {
            return BitConverter.ToString(ba).Split('-');
        }

        public static byte[] HexStringToByteArray(String hexString)
        {
            int NumberChars = hexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            return bytes;
        }
        public static int[] ByteArrayToIntArray(byte[] ba)
        {
            int[] bytesAsInts = ba.Select(x => (int)x).ToArray();
            return bytesAsInts;
        }

        public static byte[] IntArrayToByteArray(int[] Max255)
        {
            byte[] bytes = Max255.Select(x => (byte)x).ToArray();
            return bytes;
        }

        public static string IntArrayTostring(int[] Max255)
        {
            return string.Join("-", Max255.Select(i => i.ToString()).ToArray());
        }

        public static int[] StringToIntArray(string Max255String)
        {
            string[] buffer = Max255String.Split('-');
            return buffer.Select(x => Convert.ToInt32(x)).ToArray();
        }
        //public static byte[] StringToByteArray2(String hex)
        //{
        //    int NumberChars = hex.Length / 2;
        //    byte[] bytes = new byte[NumberChars];
        //    using (var sr = new StringReader(hex))
        //    {
        //        for (int i = 0; i < NumberChars; i++)
        //            bytes[i] =
        //              Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
        //    }
        //    return bytes;
        //}

        public static string BitmapToURL(Bitmap img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            //return byteArray;
            Byte[] bytes = byteArray;

            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            return "data:image/png;base64," + base64String;
        }
        public static string ByteArraytoURL(byte[] xx)
        {
            Byte[] bytes = xx;

            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            return "data:image/png;base64," + base64String;

            //Image1.ImageUrl = "data:image/png;base64," + base64String;

            //Image1.Visible = true;
        }

        //int myInt = 2934;
        //string myHex = myInt.ToString("X");  // gives you hex
        //int myNewInt = Convert.ToInt32(myHex, 16);  // back to int again.

        /// <summary>
        /// //ZIP and UNZIP
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] ZipString(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string StringUnzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static string IntToBase64(long xx)
        {
            string a = "";
            while (xx >= 1)
            {
                int index = Convert.ToInt16(xx - (xx / 64) * 64);
                a = Tianshu.CodeMap.Base64Code[index] + a;
                xx = xx / 64;
            }
            return a;
        }

        public static long Base64ToInt(string xx)
        {
            long a = 0;
            int power = xx.Length - 1;

            for (int i = 0; i <= power; i++)
            {
                a += Tianshu.CodeMap._Base64Code[xx[power - i].ToString()] * Convert.ToInt64(Math.Pow(64, i));
            }

            return a;
        }


        public static string IntToTaiChi64(long xx)
        {
            string a = "";
            while (xx >= 1)
            {
                int index = Convert.ToInt16(xx - (xx / 64) * 64);
                a = Tianshu.CodeMap.TaiChi64Code[index] + a;
                xx = xx / 64;
            }
            return a;
        }

        public static long TaiChi64ToInt(string xx)
        {
            long a = 0;
            int power = xx.Length - 1;

            for (int i = 0; i <= power; i++)
            {
                a += Tianshu.CodeMap._TaiChi64Code[xx[power - i]] * Convert.ToInt64(Math.Pow(64, i));
            }

            return a;
        }

        public static string Base64ToTaiChi64(string Base64)
        {
            return new string(Base64.ToList().Select(c => c == '=' ? c : Tianshu.CodeMap.TaiChi64Code[Tianshu.CodeMap._Base64Code[c.ToString()]]).ToArray());
        }

        public static string TaiChi64ToBase64(string TaiChi64)
        {
            return new string(TaiChi64.ToList().Select(c => c == '=' ? c : Convert.ToChar(Tianshu.CodeMap.Base64Code[Tianshu.CodeMap._TaiChi64Code[c]])).ToArray());
        }



    }
}
