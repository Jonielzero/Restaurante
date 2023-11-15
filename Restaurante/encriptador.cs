using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Restaurante
{
    public class Encriptador
    {
        private static readonly string key = "1234567890abcdef";
        private static readonly string iv = "1234567890abcabc";

        public static void EncryptTextToFile(string text, string filePath)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (FileStream fsEncrypt = new FileStream(filePath, FileMode.Create))
                using (CryptoStream csEncrypt = new CryptoStream(fsEncrypt, encryptor, CryptoStreamMode.Write))
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    
                    swEncrypt.Write(text);
                }
            }
        }

        public static string DecryptTextFromFile(string filePath)
        {
            using (Aes aesAlg = Aes.Create())
            {
                try
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(iv);
                    aesAlg.Padding = PaddingMode.PKCS7;
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (FileStream fsDecrypt = new FileStream(filePath, FileMode.Open))
                    using (CryptoStream csDecrypt = new CryptoStream(fsDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desencriptar el archivo: " + ex.Message);
                    return "";
                }
            }
        }
    }
}
