namespace StackOfStrings
{
    using System.Collections.Generic;
    using System.Linq;

    public class StackOfStrings
    {
        public StackOfStrings(List<string> data)
        {
            this.data = data;
        }

        private List<string> data;

        public void Push(string element)
        {
            this.data.Add(element);
        }

        public string Pop()
        {
            var element = this.data.Last();
            this.data.Remove(element);
            return element;
        }

        public string Peek()
        {
            var element = this.data.Last();
            return element;
        }

        public bool IsEmpty()
        {
            if (this.data.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
