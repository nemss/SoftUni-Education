namespace CreateCustomClassAtrribute.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InfoAttribute : Attribute
    {
        public InfoAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; protected set; }
        public int Revision { get; protected set; }
        public string Description { get; protected set; }
        public IList<string> Reviewers { get; protected set; }

        public string PrintInfo(string field)
        {
            var sb = new StringBuilder();

            switch (field)
            {
                case "Author":
                    sb.AppendLine($"Author: {this.Author}");
                    break;

                case "Revision":
                    sb.AppendLine($"Revision: {this.Revision}");
                    break;

                case "Description":
                    sb.AppendLine($"Class description: {this.Description}");
                    break;

                case "Reviewers":
                    sb.AppendLine($"Reviewers: {string.Join(", ", this.Reviewers)}");
                    break;
            }

            return sb.ToString().Trim();
        }
    }
}