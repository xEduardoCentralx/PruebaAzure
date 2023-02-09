﻿using System.Security.Cryptography;
using System.Text;
namespace Campañas.Recursos
{
    public class Utilidades
    {
        public static string EncriptarContra(string Contra)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(Contra));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
