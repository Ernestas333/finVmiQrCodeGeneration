using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finVmiQrCodeGeneration
{
    internal class Decompression
    {
        public string Decompress(string json)
        {
            byte[] inputBytes = Convert.FromBase64String(json);

            using (var inputStream = new MemoryStream(inputBytes))
            using (var gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(gZipStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
