namespace SimpleMvc.Framework.Controllers
{
    using Contracts;
    using Contracts.Generics;
    using Helpers;
    using System.Runtime.CompilerServices;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controllerName, caller);

            return new ActionResult(viewFullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            var viewFullQualifiedName = ControllerHelpers
                .GetFullQualifiedName(controller, action);

            return new ActionResult(viewFullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            var controllerName = ControllerHelpers.GetControllerName(this);

            var viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controllerName, caller);

            return new ActionResult<T>(viewFullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            var viewFullQualifiedName = ControllerHelpers.GetFullQualifiedName(controller, action);

            return new ActionResult<T>(viewFullQualifiedName, model);
        }
    }
}