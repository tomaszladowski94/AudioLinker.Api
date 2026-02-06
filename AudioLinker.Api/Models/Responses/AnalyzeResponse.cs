namespace AudioLinker.Api.Models.Responses
{
    public class AnalyzeResponse
    {
        public bool IsYouTubeLink { get; set; }
        public string VideoId { get; set; }
        public string Message { get; set; }
    }
}
