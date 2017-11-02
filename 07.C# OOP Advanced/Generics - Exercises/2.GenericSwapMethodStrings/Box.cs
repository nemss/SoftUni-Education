namespace _2.GenericSwapMethodStrings
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box()
        {
            this.data = new List<T>();
        }

        private List<T> data;

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public void Swap(int indexOne, int indexTwo)
        {
            var takenElementWithIndexOne = this.data[indexOne];
            var takeElementWithIndexTwo = this.data[indexTwo];

            this.data[indexOne] = takeElementWithIndexTwo;
            this.data[indexTwo] = takenElementWithIndexOne;
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