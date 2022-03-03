using AJSExample.Data.Dtos;

namespace AJSExample.Helpers
{
    public class Files
    {
        public static async Task WriteFileOnServer(string path, FileUploadRequest file)
        {
            var fullPath = Path.Combine(path, "uploads\\");
            var fileData = Convert.FromBase64String(file.Content.Base64WithoutHeader());
            await File.WriteAllBytesAsync(fullPath + file.Name, fileData);
        }
    }
}