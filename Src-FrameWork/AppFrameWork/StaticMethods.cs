using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppFrameWork
{
    public static class StaticMethods
    {
        public static string FormatStringInGroups(string input,int groupsize,bool IsPrice=false)
        {
            var stringResult=new StringBuilder();
            for(int i =0; i<input.Length;i++)
            {
                stringResult.Append(input[i]);
                if(!IsPrice)
                {
                    if ((i + 1) % groupsize == 0 && i != input.Length - 1)
                    {
                        stringResult.Append('-');
                    }
                }
                else
                {
                    if ((i + 1) % groupsize == 0 && i != input.Length - 1)
                    {
                        stringResult.Append(',');
                    }
                }
            }
            return stringResult.ToString();
        }
        public async static Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
                fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                    filePath = Path.Combine($"wwwroot/images/{folderName}", fileName);           
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await FormFile.CopyToAsync(stream, cancellation);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                 return $"{fileName}";       
            }
            else
                fileName = "";

            return fileName;
        }

    }
}
