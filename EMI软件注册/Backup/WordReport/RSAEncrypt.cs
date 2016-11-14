using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.IO;


namespace WordReport
{
    class RSAEncrypt
    {

        private string keysPath = "";

        public string PublicKey;
        private string PrivateKey;

        private string d, e, n;

        RSACryptoServiceProvider rsaProvider;
        FileOperator fop = new FileOperator();

        XmlDocument xmlDoc = new XmlDocument();
       

        public RSAEncrypt()
        {

        }

        public RSAEncrypt(string _keysPath)
        {
            keysPath = _keysPath;
        }

        /*public void Initial()
        {
            rsaProvider = new RSACryptoServiceProvider(1024);

            if (!Directory.Exists(keysPath))
                Directory.CreateDirectory(keysPath);
            string pathPublic = Path.Combine(keysPath, "PublicKey.xml");
            string pathPrivate = Path.Combine(keysPath, "PrivateKey.xml");

            PublicKey = rsaProvider.ToXmlString(false);
            PrivateKey = rsaProvider.ToXmlString(true);

            fop.WriteFile(pathPublic, PublicKey);
            fop.WriteFile(pathPrivate, PrivateKey);

            xmlDoc.LoadXml(PrivateKey);

            d = GetXmlValue("D");
            e = GetXmlValue("Exponent");
            n = GetXmlValue("Modulus");
        }*/

        public void Initial()
        {
            if (!Directory.Exists(keysPath))
            {
                GenericKey();
            }
            
            string pathPublic = Path.Combine(keysPath, "PublicKey.xml");
            string pathPrivate = Path.Combine(keysPath, "PrivateKey.xml");
            if(!File.Exists(pathPublic) || !File.Exists(pathPrivate))
            {
                GenericKey();
            }

            PublicKey = fop.ReadFile(pathPublic);
            PrivateKey = fop.ReadFile(pathPrivate);

            xmlDoc.LoadXml(PrivateKey);

            d = GetXmlValue("D");
            e = GetXmlValue("Exponent");
            n = GetXmlValue("Modulus");
        }

        public void GenericKey()
        {
            rsaProvider = new RSACryptoServiceProvider(1024);

            if (!Directory.Exists(keysPath))
                Directory.CreateDirectory(keysPath);
            string pathPublic = Path.Combine(keysPath, "PublicKey.xml");
            string pathPrivate = Path.Combine(keysPath, "PrivateKey.xml");

            PublicKey = rsaProvider.ToXmlString(false);
            PrivateKey = rsaProvider.ToXmlString(true);

            fop.WriteFile(pathPublic, PublicKey);
            fop.WriteFile(pathPrivate, PrivateKey);
        }


        public string EncrytoData(string data)
        {
            byte[] encrytoData;
            string strRet = "";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            rsa.FromXmlString(PublicKey);
            byte[] da = Encoding.ASCII.GetBytes(data);
            encrytoData = rsa.Encrypt(da, false);
            strRet = Encoding.ASCII.GetString(encrytoData);

            return strRet;

        }

        public string DecrytoData(string data)
        {
            byte[] decrytoData;
            string strRet = "";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            rsa.FromXmlString(PrivateKey);
            decrytoData = rsa.Encrypt(Encoding.ASCII.GetBytes(data), false);

            strRet = Encoding.ASCII.GetString(decrytoData);

            return strRet;
        }

        /// <summary>
        /// 功能：用指定的私钥(n,d)加密指定字符串source
        /// </summary>
        /// <param name="source"></param>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private string EncryptString(string source, BigInteger d, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 128) == 0)
                len1 = len / 128;
            else
                len1 = len / 128 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 128)
                    blockLen = 128;
                else
                    blockLen = len;
                block = source.Substring(i * 128, blockLen);
                byte[] oText = System.Text.Encoding.Default.GetBytes(block);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(d, n);
                string temp1 = biEnText.ToHexString();
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }

        /// <summary>
        /// 功能：用指定的公钥(n,e)解密指定字符串source 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private string DecryptString(string source, BigInteger e, BigInteger n)
        {
            int len = source.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 256) == 0)
                len1 = len / 256;
            else
                len1 = len / 256 + 1;
            string block = "";
            string temp = "";
            for (int i = 0; i < len1; i++)
            {
                if (len >= 256)
                    blockLen = 256;
                else
                    blockLen = len;
                block = source.Substring(i * 256, blockLen);
                BigInteger biText = new BigInteger(block, 16);
                BigInteger biEnText = biText.modPow(e, n);
                string temp1 = System.Text.Encoding.Default.GetString(biEnText.getBytes());
                temp += temp1;
                len -= blockLen;
            }
            return temp;
        }


        //加密过程和解密过程代码如下所示：
        /// <summary>
        ///  加密过程,其中d、n是RSACryptoServiceProvider生成的D、Modulus   
        /// </summary>
        /// <param name="source"></param>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string EncryptProcess(string source)
        {
            byte[] N = Convert.FromBase64String(n);
            byte[] D = Convert.FromBase64String(d);
            BigInteger biN = new BigInteger(N);
            BigInteger biD = new BigInteger(D);
            return EncryptString(source, biD, biN);
        }

        /// <summary>
        ///  解密过程,其中e、n是RSACryptoServiceProvider生成的Exponent、Modulus  
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string DecryptProcess(string source)
        {
            byte[] N = Convert.FromBase64String(n);
            byte[] E = Convert.FromBase64String(e);
            BigInteger biN = new BigInteger(N);
            BigInteger biE = new BigInteger(E);
            return DecryptString(source, biE, biN);
        }


        private string GetXmlValue(string tagName)
        {
            XmlNode xe = xmlDoc.GetElementsByTagName(tagName)[0];
            string txtValue = xe.InnerText.Trim();

            return txtValue;
 
        }

        public string ToBase64String(string sourceInfo)
        {
            string base64Ret = "";
            base64Ret = Convert.ToBase64String(Encoding.ASCII.GetBytes(sourceInfo));

            return base64Ret;
        }


        public string FromBase64String(string sourceInfo)
        {
            string base64Ret = "";
            base64Ret = Encoding.ASCII.GetString(Convert.FromBase64String(sourceInfo));

            return base64Ret;
        }

    }
}
