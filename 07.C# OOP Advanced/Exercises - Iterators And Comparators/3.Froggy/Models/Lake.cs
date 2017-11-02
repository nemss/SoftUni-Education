namespace _3.Froggy.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Lake<T> : IEnumerable<T>
    {
        private readonly List<T> stones;

        public Lake()
        {
            this.stones = new List<T>();
        }

        public Lake(List<T> collection)
        {
            this.stones = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            var lastIndex = (this.stones.Count - 1) % 2 == 0 ? this.stones.Count() - 2 : this.stones.Count() - 1;

            for (int i = lastIndex; i > 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}