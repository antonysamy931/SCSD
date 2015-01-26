using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SCSD.Web.Models.Common
{
    public static class CheckSumGenerator
    {
        public static string GetCheckSum(Stream file)
        {
            HashAlgorithm SHA512 = new SHA512Managed();            
            byte[] hash = SHA512.ComputeHash(file);
            return Convert.ToBase64String(hash.ToArray());
        }

        public static byte[] GetByteFromStream(Stream file,int length)
        {
            byte[] imgByte = null;
            using (BinaryReader breader = new BinaryReader(file))
            {
                imgByte = breader.ReadBytes(length);
            }
            return imgByte;
        }
    }
}