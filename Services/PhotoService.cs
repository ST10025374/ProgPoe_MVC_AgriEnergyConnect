using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using ProgPoe_MVC_AgriEnergyConnect.Helpers;
using ProgPoe_MVC_AgriEnergyConnect.Interfaces;

namespace ProgPoe_MVC_AgriEnergyConnect.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoService"/> class.
        /// </summary>
        /// <param name="config">The Cloudinary settings.</param>
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Adds a photo asynchronously.
        /// </summary>
        /// <param name="file">The photo file to upload.</param>
        /// <returns>The result of the image upload.</returns>
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Deletes a photo asynchronously.
        /// </summary>
        /// <param name="publicId">The public ID of the photo to delete.</param>
        /// <returns>The result of the photo deletion.</returns>
        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 