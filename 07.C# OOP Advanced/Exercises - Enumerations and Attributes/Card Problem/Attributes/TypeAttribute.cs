using System;

namespace Card_Problem.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = true)]
    internal class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; private set; }
        public string Category { get; private set; }
        public string Description { get; protected set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
}