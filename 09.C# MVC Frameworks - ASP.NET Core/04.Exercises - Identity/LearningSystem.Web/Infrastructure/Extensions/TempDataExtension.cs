namespace LearningSystem.Web.Infrastructure.Extensions
{
    using Constants;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class TempDataExtension
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessage] = message;
        }
    }
}