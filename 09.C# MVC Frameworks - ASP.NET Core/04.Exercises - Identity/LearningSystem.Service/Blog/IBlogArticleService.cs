namespace LearningSystem.Service.Blog
{
    using System.Threading.Tasks;

    public interface IBlogArticleService
    {
        Task CreateAsync(string title, string content, string authorId);
    }
}
