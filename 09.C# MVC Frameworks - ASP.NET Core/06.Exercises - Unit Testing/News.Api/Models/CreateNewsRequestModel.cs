namespace News.Api.Models
{
    using System;

    public class CreateNewsRequestModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PusblishDate { get; set; }
    }
}
