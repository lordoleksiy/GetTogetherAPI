using GetTogether.Common.Enums;

namespace GetTogether.Common.DTO.Image;

public class NewImageDTO
{
    public Stream Stream { get; set; }
    public string FileName { get; set; }
    public ImageType Type { get; set; }
    public NewImageDTO(Stream stream, string filename, ImageType type) 
    {
        Stream = stream;
        FileName = filename;
        Type = type;
    }
}
