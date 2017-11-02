namespace SimpleMvc.Framework.ViewEngine
{
    using Contracts;
    using System;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(Type.GetType(viewFullQualifedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
            => this.Action.Render();
    }
}