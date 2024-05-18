using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CoreLayer.Utilities
{
    public class ImageOptimizer
    {
        public void ImageResizer(string InputImagePath, string OutputImagePath, int? Width, int? Height)
        {
            var CustomWidth = Width ?? 100;

            var CustomHeight = Height ?? 100;

            using (var Image = SixLabors.ImageSharp.Image.Load(InputImagePath))
            {
                Image.Mutate(x => x.Resize(CustomWidth, CustomHeight));

                Image.Save(OutputImagePath, new JpegEncoder
                {
                    Quality = 100
                });
            }
        }
    }

    public static class CheckContentImage
    {
        public const int ImageMinimumBytes = 512;

        #region (Is Image)
        public static bool IsImage(this IFormFile PostedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (PostedFile.ContentType.ToLower() != "image/jpg" &&
                        PostedFile.ContentType.ToLower() != "image/jpeg" &&
                        PostedFile.ContentType.ToLower() != "image/pjpeg" &&
                        PostedFile.ContentType.ToLower() != "image/x-png" &&
                        PostedFile.ContentType.ToLower() != "image/png" &&
                        PostedFile.ContentType.ToLower() != "image/webp")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(PostedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(PostedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(PostedFile.FileName).ToLower() != ".jpeg" 
                && Path.GetExtension(PostedFile.FileName).ToLower() != ".webp")
                
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!PostedFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                //------------------------------------------
                //check whether the image size exceeding the limit or not
                //------------------------------------------ 
                if (PostedFile.Length < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                PostedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            return true;
        }
        #endregion
    }
}
