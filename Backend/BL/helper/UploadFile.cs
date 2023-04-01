namespace WebApplication6.BL.helper
{
    public class UploadFile
    {
        public static string SaveFile(IFormFile FileUrl, string FolderName)
        {
            string FilePath = "C:/Users/engfa/Projects/Clothes/src/" + FolderName;
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);
            string FinalPath = Path.Combine(FilePath, FileName);
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }
            return FileName;
        }
        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists("C:/Users/engfa/Projects/Clothes/src/" + FolderName + "/" + RemovedFileName))
            {
                File.Delete("C:/Users/engfa/Projects/Clothes/src/" + FolderName + "/" + RemovedFileName);
            }
        }
    }
}
