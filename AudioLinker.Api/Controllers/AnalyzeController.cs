using AudioLinker.Api.Models.Requests;
using AudioLinker.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AudioLinker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzeController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] AnalyzeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Url))
            {
                return BadRequest("Url cannot be empty.");
            }

            bool isYouTube = request.Url.Contains("youtube.com") || request.Url.Contains("youtu.be");
            string videoId = null;

            if (isYouTube)
            {
                if (request.Url.Contains("v="))
                {
                    var query = request.Url.Split("v=")[1];
                    var ampIndex = query.IndexOf('&');
                    videoId = ampIndex > -1 ? query.Substring(0, ampIndex) : query;
                }
                else if (request.Url.Contains("youtu.be/"))
                {
                    var parts = request.Url.Split("youtu.be/");
                    videoId = parts.Length > 1 ? parts[1] : null;
                }
            }

            var response = new AnalyzeResponse
            {
                IsYouTubeLink = isYouTube,
                VideoId = videoId,
                Message = isYouTube ? "Poprawny link YouTube" : "To nie jest link YouTube"
            };

            return Ok(response);
        }
    }
}
