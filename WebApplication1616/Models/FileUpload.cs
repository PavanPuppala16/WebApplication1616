namespace WebApplication1616.Models
{
    public class FileUpload
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
