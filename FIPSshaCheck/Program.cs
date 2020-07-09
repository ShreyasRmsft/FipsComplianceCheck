using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace FIPSshaCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var algorithm = new SHA1CryptoServiceProvider();
            var alternateConstructor = SHA1.Create();

            Console.WriteLine("\nSHA1 Hash with SHA1CryptoServiceProvider():");
            ComputeHash(algorithm);
            Console.WriteLine("\nSHA1 Hash with SHA1.Create():");
            ComputeHash(alternateConstructor);

            Console.WriteLine(computeMd5());
        }

        public static void ComputeHash(HashAlgorithm algorithm)
        {
            StringBuilder signature = new StringBuilder(20);
            signature.Length = 0;
            var name = "c:\\abc\\def";

            // Compute the hash from the bytes of the string
            byte[] hash = algorithm.ComputeHash(Encoding.Unicode.GetBytes(name));

            foreach (byte b in hash)
            {
                signature.Append(b.ToString("X2", CultureInfo.InvariantCulture));
            }

            Console.WriteLine(signature);
        }

        protected static string computeMd5()
        {
            string toPrint = String.Empty;
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                toPrint = "Created algorithm.";
            }
            catch (Exception e)
            {
                toPrint = e.ToString();
            }
            return toPrint;
        }
    }
}
