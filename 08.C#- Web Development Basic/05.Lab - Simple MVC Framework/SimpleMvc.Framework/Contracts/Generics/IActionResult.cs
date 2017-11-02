namespace SimpleMvc.Framework.Contracts.Generics
{
    public interface IActionResult<TModel> : IInvocable
    {
        IRenderable<TModel> Action { get; set; }
    }
}