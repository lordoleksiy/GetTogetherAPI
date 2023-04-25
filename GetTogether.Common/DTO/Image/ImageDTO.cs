namespace GetTogether.Common.DTO.Image;

public class ImageDTO
{
    public string FileName { get; set; }
    public string ImageUrl { get; set; }
    public ImageDTO(string name, string url)
    {
        FileName = name;
        ImageUrl = url;
    }
}
