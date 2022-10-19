﻿using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Tunetoon.BZip2;
using Tunetoon.Utilities;

namespace Tunetoon {
    internal static class GamePatchUtils 
    {
        public static string GetSha1FileHash(string filepath)
        {
            try
            {
                using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                using (var sha1Cng = new SHA1Cng())
                {
                    return Hex(sha1Cng.ComputeHash(fs));
                }
            }
            catch
            { 
                return null;
            }
        }

        public static string GetSha1HashString(string str)
        {
            try
            {
                using (var sha1Cng = new SHA1Cng())
                {
                    return Hex(sha1Cng.ComputeHash(Encoding.UTF8.GetBytes(str)));
                }
            }
            catch
            {
                return null;
            }
        }

        private static string Hex(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        public static void Decompress(string compressedFile, string localFile, string type)
        {
            using (var fs = new FileStream(compressedFile, FileMode.Open, FileAccess.Read))
            using (var fsOut = File.Create(localFile))
            {
                if (type == "bzip2")
                {
                    BZip2Decompressor.Decompress(fs, fsOut, true);
                }
                else if (type == "gzip")
                {
                    using (var GZipDecompressor = new GZipStream(fs, CompressionMode.Decompress))
                    {
                        GZipDecompressor.CopyTo(fsOut);
                    }
                }
            }
        }

        public static int Extract(string downloadedFilePath, string extractedFilePath, string type)
        {
            try
            {
                Decompress(downloadedFilePath, extractedFilePath, type);
                return 0;
            }
            catch
            {
                File.Delete(extractedFilePath);
                return -1;
            }
            finally
            {
                File.Delete(downloadedFilePath);
            }
        }

        public static bool FileIsCorrect(string filePath, string compHash)
        {
            string fileHash = GetSha1FileHash(filePath);

            if (fileHash == compHash)
            {
                return true;
            }
            return false;
        }

        public static void Patch(string patchFile, string localFile)
        {
            BsPatch.Apply(localFile, patchFile);
        }
    }
}
