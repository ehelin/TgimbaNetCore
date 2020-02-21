namespace Shared.dto
{
    public class InitializeResult
    {
        public bool IsMobile { get; set; }
        public string[] AvailableSortingAlgorithms { get; set; }
        public string[] AvailableSearchingAlgorithms { get; set; }
    }
}
