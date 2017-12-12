namespace News.Services.Models
{
    using System;

    public class NewsListingServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
