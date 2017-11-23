namespace GameraBazaar.Services.Interfaces
{
    using Data.Models;
    using Models.Cameras;
    using System.Collections.Generic;

    public interface ICameraService
    {
        void Create(
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMetering,
            string description,
            string imageUrl,
            string userId);

        CameraDetailsModel Details(int id);

        void Delete(int id);

        bool Edit(
            int id,
            CameraMake make,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMetering,
            string description,
            string imageUrl,
            string userId);

        bool Exists(int id, string userId);

        IEnumerable<CameraListModel> All();
    }
}
