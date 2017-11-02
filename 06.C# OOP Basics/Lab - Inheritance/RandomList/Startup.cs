using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomList
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = Console.ReadLine();
            var randomList = new RandomList();
           randomList.AddList(list);
           randomList.RandomString();
        }
    }
}
