namespace SimpleMvc.Framework.Contracts.Generics
{
    public interface IRenderable<TModel> : IRenderable
    {
        TModel Model { get; set; }
    }
}