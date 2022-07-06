namespace RaceCarSetup
{
    /// <summary>
    /// Entity for holding the Car configuration and race completion time
    /// </summary>
    public class RaceCompletionResult
    {
        /// <summary>
        /// Car configuration
        /// </summary>
        public CarConfiguration CarConfiguration { get; set; }
        /// <summary>
        /// Time taken to complete the entire race in mins
        /// </summary>
        public int RaceCompletionTime { get; set; }
    }


}
