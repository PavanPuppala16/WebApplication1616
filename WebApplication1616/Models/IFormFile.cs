namespace WebApplication1616.Models
{
    public class IFormFile
    {
       public string ContentType { get; }
        string ContentDisposition { get; }
        IHeaderDictionary Headers { get; }
        long Length { get; }
        string Name { get; }
        string FileName { get; }

      
    }
}
