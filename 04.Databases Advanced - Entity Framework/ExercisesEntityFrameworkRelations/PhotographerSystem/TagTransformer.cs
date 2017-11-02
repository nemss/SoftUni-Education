namespace PhotographerSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class TagTransformer
    {
        public static string Transform(string tagValue)
        {
            if(!tagValue.StartsWith("#"))
            {
                tagValue = "#" + tagValue;
            }

            if(tagValue.Contains(" "))
                {
                tagValue.Replace(" ", string.Empty);
            }

            if(tagValue.Contains("\t"))
            {
                tagValue.Replace("\t", string.Empty);
            }

            if(tagValue.Length > 20)
            {
               tagValue =  tagValue.Substring(0, 20);
            }
            return tagValue;
        }
    }
}
