using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MD5与Hash基础
{
    class Program
    {
        static void Main(string[] args)
        {
            //MD5与Hash基础
            string value = "Hello World";
            Byte[] data = Encoding.UTF8.GetBytes(value);
            //字节长度要除8
            //MD5--16字节
            var md5 = MD5.Create();
            Byte[] hash = md5.ComputeHash(data);
            Console.WriteLine(hash.Length);
            Console.WriteLine((string.Concat(hash.Select(t => t.ToString("X2")))));
            //SHA1--20字节
            var sha1 = SHA1.Create();
            hash = sha1.ComputeHash(data);
            Console.WriteLine(hash.Length);
            Console.WriteLine((string.Concat(hash.Select(t => t.ToString("X2")))));
            //SHA256--32字节
            var sha256 = SHA256.Create();
            hash = sha256.ComputeHash(data);
            Console.WriteLine(hash.Length);
            Console.WriteLine((string.Concat(hash.Select(t => t.ToString("X2")))));
        }
    }
}
