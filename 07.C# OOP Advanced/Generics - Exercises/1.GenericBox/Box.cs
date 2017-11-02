namespace _1.GenericBox
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in data)
            {
                sb.AppendLine($"{element.GetType().FullName}: {element}");
            }

            return sb.ToString().Trim();
        }
    }
}