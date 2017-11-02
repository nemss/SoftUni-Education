namespace _02.SocialNetwork.Data.Logic
{
    public static class TagTransform
    {
        public static string Transform(string tag)
        {
            var result = tag.Replace(" ", string.Empty);

            if (!result.StartsWith("#"))
            {
                result = "#" + result;
            }

            if (result.Length > 20)
            {
                result = result.Substring(0, 20);
            }

            return result;
        }
    }
}
