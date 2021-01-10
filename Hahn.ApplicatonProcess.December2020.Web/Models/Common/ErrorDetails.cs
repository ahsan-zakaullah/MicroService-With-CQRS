using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.December2020.Web.Models.Common
{
    /// <summary>
    /// model for error details for logging errors using middleware
    /// </summary>
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
