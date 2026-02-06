using System.ComponentModel.DataAnnotations;

namespace AudioLinker.Api.Models.Requests
{
    public class AnalyzeRequest
    {
        [Required(ErrorMessage = "Video url is required.")]
        public string Url { get; set; }
    }
}
