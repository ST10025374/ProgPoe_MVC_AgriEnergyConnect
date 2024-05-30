using CloudinaryDotNet.Actions;

namespace ProgPoe_MVC_AgriEnergyConnect.Interfaces
{
    public interface IPhotoService
    {
        /// <summary>
        /// Adds a photo asynchronously.
        /// </summary>
        /// <param name="file">The file to be added.</param>
        /// <returns>The result of the image upload.</returns>
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        /// <summary>
        /// Deletes a photo asynchronously.
        /// </summary>
        /// <param name="publicUrl">The public URL of the photo to be deleted.</param>
        /// <returns>The result of the deletion operation.</returns>
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 