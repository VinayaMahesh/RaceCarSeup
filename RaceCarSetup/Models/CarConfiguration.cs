namespace RaceCarSetup
{
    /// <summary>
    /// Entity for Car configurations
    /// </summary>
    public class CarConfiguration
    {
        /// <summary>
        /// Total fuel capacity in lts
        /// </summary>
        public int FuelCapacity { get; set; }
        /// <summary>
        /// Time to complete one lap in mins
        /// </summary>
        public int TimeToCompleteOneLap { get; set; }
        /// <summary>
        /// Average fuel per lap in lts
        /// </summary>
        public int AverageFuelPerLap { get; set; }
    }
}
