export interface AnalyzeResponse {
  isYouTubeLink: boolean;
  videoId: string | null;
  message: string;
}