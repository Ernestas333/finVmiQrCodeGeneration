using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace finVmiQrCodeGeneration
{
    internal class Compression
	{
        public string Compress(string json)
        {
            string cleanedupJson = RemoveSpaces(json);
            cleanedupJson = Regex.Replace(cleanedupJson, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
            byte[] bytes = Encoding.UTF8.GetBytes(cleanedupJson);
            return Compress(bytes);
        }

        public string Compress(byte[] input)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    gZipStream.Write(input, 0, input.Length);

                return Convert.ToBase64String(outputStream.ToArray());
            }
        }

        private static string RemoveSpaces(string json)
        {
            return json.Replace("\n", "").Replace("\r", "").Trim();
        }
    }
}
