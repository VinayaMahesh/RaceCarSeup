using System.Collections.Generic;

namespace RaceCarSetup
{
    /// <summary>
    /// Business logic for race car setup
    /// </summary>
    public interface IRaceCarBusiness
    {
        /// <summary>
        /// Gets the Car configurations by rank for Race track provided
        /// </summary>
        /// <param name="carConfigurations">Set of car configurations</param>
        /// <param name="raceTrack">Race track</param>
        /// <returns>Car configurations by rank by race completion time</returns>
        IEnumerable<(RaceCompletionResult CarConfig, int Rank)> GetCarConfigurationsByRaceTime(IEnumerable<CarConfiguration> carConfigurations,RaceTrack raceTrack);
    }

}
