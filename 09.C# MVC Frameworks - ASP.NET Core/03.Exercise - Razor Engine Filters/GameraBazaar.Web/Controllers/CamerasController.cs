namespace GameraBazaar.Web.Controllers
{
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Cameras;
    using Services.Interfaces;

    public class CamerasController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICameraService cameras;

        public CamerasController(UserManager<User> userManager, ICameraService cameras)
        {
            this.userManager = userManager;
            this.cameras = cameras;
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(CameraFormModel cameraModel)
        {
            if (cameraModel.LightMetering == null || !cameraModel.LightMetering.Any())
            {
                ModelState.AddModelError(nameof(cameraModel.LightMetering), "Please select at least one light metering.");
            }

            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var cameraExists = this.cameras.Exists(id, this.userManager.GetUserId(User));

            if (!cameraExists)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, CameraFormModel cameraModel)
        {
          var update = this.cameras.Edit(
                id,
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.Description,
                cameraModel.ImageUrl,
                this.userManager.GetUserId(User));

            if (!update)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(CamerasController.All));
        }

        public IActionResult All() 
            => View(this.cameras.All());

        public IActionResult Details(int id)
            => View(this.cameras.Details(id));
    }
}