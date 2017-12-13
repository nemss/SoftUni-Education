namespace News.Tests.Api
{
    using News.Api.Controllers;
    using Xunit;

    public class EndpointTests
    {
        [Fact]
        public void NewsControllerAll_ReturnOkStatusCode()
        {
            var newsController = new NewsController(I);
        }

    }
}
