using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EG.Web.Core.Extensions
{
    public static class CommonExtension
    {
        public static string PasswordHashed(this string Password,string PasswordSalt)
        {
            string concatSaltAndPassword = string.Concat(Password, PasswordSalt);
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(concatSaltAndPassword));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        public static async Task UploadFile(this IFormFile file, string Path)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            using (var fileStream = new FileStream(Path + "\\" + file.FileName, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
