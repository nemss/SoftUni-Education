namespace GameraBazaar.Services.Implementations
{
    using Data;
    using Data.Models;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class CameraService : ICameraService
    {
        private readonly GameraBazaarDbContext db;

        public CameraService(GameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void Create(
            CameraMake make, 
            string model, decimal price, 
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
            string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LIsLightMetering = (LightMetering)lightMetering.Cast<int>().Sum(),
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }
    }
}
