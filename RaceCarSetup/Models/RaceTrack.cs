namespace RaceCarSetup
{
    /// <summary>
    /// Entity for Race track
    /// </summary>
    public class RaceTrack
    {
        /// <summary>
        /// Lap distance in km
        /// </summary>
        public int LapDistance { get; set; }
        /// <summary>
        /// Total laps
        /// </summary>
        public int NoOfLaps { get; set; }
        /// <summary>
        /// Pit stop time in mins
        /// </summary>
        public int TimeToMakePitStop { get; set; }
    }
}
