using Microsoft.AspNetCore.Http;

namespace CheckIT.API.Helpers
{
    //Adds helpers for displaying error messages.
    //check startup.cs
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message) 
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}