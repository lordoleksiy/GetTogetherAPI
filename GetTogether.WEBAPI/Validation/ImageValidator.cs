using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.WEBAPI.Validation;

public static class ImageValidator
{
    public static bool Validate(this IFormFile image)
    {
        if (image == null || image.Length == 0)
        {
            throw new ArgumentNullException("No image provided!");
        }

        if (image.ContentType != "image/jpeg" && image.ContentType != "image/png")
        {
            throw new ArgumentException("Wrong type of image!");
        }

        return true;
    }
}
