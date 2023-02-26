using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)//Dosya uzunluğunu bayt olarak aldık.Dosya gönderildi mi diye bakmak için
            {
                if (!Directory.Exists(root)) //PathContans classına gidiyor. Orada resimin kayıt edileceği yol var. Directory.Exists(root) diyerek 
                {                               //O dizin var mı diye kontrol ediyoruz. Eğer yoksa oluştur diyoruz.
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName); //dosyanın uzantısını alıyoruz
                string guid = GuidHelper.GuidHelper.CreateGuid();
                string filePath = guid + extension; //dosya adı(guid - oluşturduğumuz benzersiz ad + dosya yolu(.jpg))

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
