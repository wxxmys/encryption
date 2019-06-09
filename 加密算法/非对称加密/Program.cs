using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace 非对称加密
{
    class Program
    {//非对称加密（RSA算法）
        static void Main(string[] args)
        {
            string value = "Hello World";
            Byte[] data = Encoding.UTF8.GetBytes(value);
            //创建非对称加密
            RSA rsa = new RSACng(2048);
            //导出私钥参数实例
            rsa.ExportParameters(true);
            //导出公钥参数实例
            rsa.ExportParameters(false);
            //导出私钥XML数据
            //第一种方法
           // Console.WriteLine(rsa.ToXmlString(true));
            //第二种方法
            var privateKey = rsa.ToXmlString(true);
            //导出公钥XML数据
            //第一种方法
            //Console.WriteLine(rsa.ToXmlString(false));
            //第二种方法
            var publicKey = rsa.ToXmlString(false);
            //创建非对称加密实例
            rsa = RSA.Create();
            rsa.FromXmlString(privateKey);
         
            while(true)
                try
            {
                value = Console.ReadLine();
                    data = Encoding.UTF8.GetBytes(value);
                    //签名
                    var signValue = rsa.SignData(data,HashAlgorithmName.SHA1,RSASignaturePadding.Pkcs1);
                    Console.WriteLine(signValue.Length);
                    Console.WriteLine(string.Concat(signValue.Select(t => t.ToString("X2"))));
                    rsa.VerifyData(data, signValue, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
        }
    }
}
