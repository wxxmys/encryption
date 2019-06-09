using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace 对称加密
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "Hello World";
            Byte[] data = Encoding.UTF8.GetBytes(value);
            Byte[] key = new byte[32];
            Random rnd = new Random();
            rnd.NextBytes(key);
            var aes = Aes.Create();
            aes.KeySize = 128;
            aes.Key = key;
            var encryptor = aes.CreateEncryptor();//加密
            var decryptor = aes.CreateDecryptor();//解密
            while (true)
                try
                {
                    value = Console.ReadLine();
                    data = Encoding.UTF8.GetBytes(value);
                    var encryptedValue = encryptor.TransformFinalBlock(data, 0, data.Length);
                    Console.WriteLine(encryptedValue.Length);
                    Console.WriteLine((string.Concat(encryptedValue.Select(t => t.ToString("X2")))));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
          
        }
      
    }
}
