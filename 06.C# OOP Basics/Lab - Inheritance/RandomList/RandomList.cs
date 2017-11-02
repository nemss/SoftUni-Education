using System.Linq;

namespace RandomList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RandomList : ArrayList
    {
        public RandomList()
        {    
            this.data = new List<string>();
            rnd = new Random();
        }
        private Random rnd;
        private List<string> data;

        public object RandomString()
        {
            var element = rnd.Next(0, data.Count - 1);
            var str = data[element];
            data.Remove(str);
            return str;
        }

        public void AddList(string info)
        {
            this.data.Add(info.Split(' ').ToString());
        }
    }
}
