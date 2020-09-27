using System;
using System.IO;
using System.Text.RegularExpressions;
using Azure.Storage.Blobs;

namespace UploadImages.Services
{
    public class FileUpload
    {
        private readonly string blobConnectionString = "BLOB CONNECTION STRING";
        public string UploadBase64Image(string base64Image, string container)
        {
            var fileName = Guid.NewGuid().ToString() + ".png";

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient(blobConnectionString, container, fileName);

            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            return blobClient.Uri.AbsoluteUri;
        }
    }
}