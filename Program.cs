using Newtonsoft.Json;
using System; 
using System.IO;
using System.Linq;


namespace finVmiQrCodeGeneration
{
    internal class Program
    { 
        internal static string base64ExampleinDocument = "H4sIAAAAAAAAAL2PS2vDMBCE/4rYs11sp3n5FuJCU5oY2mPpQUibRCBpHT0OJeS/V0qg0JBDD6EnSTuj2W+OIEk8I5fooD3mx0pCC+/9+qns+mW56qDI0yU5tyFo5/MCBJlBY1BkOx4wuZuqqcu6KasZnJIcfSBzydsq58OGm+x6ob1NYZr/TDrCNFASbVDhqyMRTbrmNVA3o8fxZDqbVzlyRyQ9tB9H8HiIaAVmU53I0AunhsySPr2SQ8PU4KNhkjQ55lVgaVcomCDrUQQM0TEu1aC8UHbHUCdHnSgOkZ8pUmxVQLQq9Ns1ch8dLklm2s3iDa6UPuxzTxu1LiBQ4HphKNoA7XjyMK5OxW/g5l7AzV+AL1S3eOF8siwx2jJzEeG6wvRGhdG9Koz+pcIsV/g8fQPCwZoC5gIAAA==";
       
        static void Main(string[] args)
        {
            //Duomenys iš QRCodo_generavimas.docx
            string jsonExample = LoadJson("Example"); // pvz pagal kurį turėtų būti suformuotas encodeBase64String (2. punktas)
            string jsonBase64  = LoadJson("Base64"); //iš encodeBase64String gauti ne tie duomenys nurodyti pavyzdyje (3.3 punktas- kintamasis base64ExampleinDocument) 
            string jsonQrCodeData = LoadJson("QrCodeData"); // išGzipinti (data) duomenys iš qr kodo (3.6 punktas)

            string shouldBeJsonFromExample = serializeSubmitRequestDeclaration(delcarationExamples.exampleRequest()); 

            string[] compressedData = new string[4] { jsonExample , jsonBase64, jsonQrCodeData, shouldBeJsonFromExample };
            int i = 0;
            foreach (string s in compressedData)
            {
                i++;
                Console.WriteLine($"PVZ {i} - Duomenys apdorojimui:");
                Console.WriteLine(s);

                Console.WriteLine(string.Concat(Enumerable.Repeat(".", 100)));
                Console.WriteLine("(3.3 punktas) Compresinam:");
                Compression compression = new Compression();
                string compressedString = compression.Compress(s);
                Console.Write(compressedString);                
                Console.WriteLine();

                Console.WriteLine(string.Concat(Enumerable.Repeat(".", 100)));
                Console.WriteLine("Decompresinam:");
                Decompression decompression = new Decompression();                
                Console.Write(decompression.Decompress(compressedString));
                Console.WriteLine();
                Console.WriteLine(string.Concat(Enumerable.Repeat("-", 100)));
                Console.WriteLine("\n\n\n\n\n");
            }
            Console.ReadLine();
        }

        public static string LoadJson(string dataFile)
        { 
            using (StreamReader r = new StreamReader($"../../Examples/{dataFile}.json"))            
                 return r.ReadToEnd(); 
        }

        public static string serializeSubmitRequestDeclaration(WebReference.submitDeclarationRequest decl)
        {
            return JsonConvert.SerializeObject(new InputDataStructure(decl)); 
        }
    }
}
