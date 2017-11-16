namespace GameraBazaar.Web.Infrastructure.Extensions
{
    using Data.Models;

    public static class EnumExtensins
    {
        public static string ToDisplayName(this LightMetering lightMetering)
        {
            if (lightMetering == LightMetering.CenterWeighted)
            {
                return "Centre-Weight";
            }

            return lightMetering.ToString();
        }
    }
}
