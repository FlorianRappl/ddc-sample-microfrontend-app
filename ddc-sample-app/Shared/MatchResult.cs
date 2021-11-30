namespace ddc_sample_app.Shared
{
    public record MatchResult(bool IsMatch, Route MatchedRoute = null);
}