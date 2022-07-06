using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceCarSetup
{

    /// <summary>
    /// Ditance and time are considered in Km and mins
    /// Business logic for race car setup.
    /// </summary>
    public class RaceCarBusiness : IRaceCarBusiness
    {
        private static int PitStopTime = 1;

        /// <summary>
        /// Gets the Car configurations by rank for Race track provided
        /// </summary>
        /// <param name="carConfigurations">Set of car configurations</param>
        /// <param name="raceTrack">Race track</param>
        /// <returns>Car configurations by rank by race completion time</returns>
        public IEnumerable<(RaceCompletionResult CarConfig, int Rank)> GetCarConfigurationsByRaceTime(IEnumerable<CarConfiguration> carConfigurations, RaceTrack raceTrack)
        {
            List<RaceCompletionResult> carConfigurationRanks = new List<RaceCompletionResult>();

            var totalRaceDistance = raceTrack.LapDistance * raceTrack.NoOfLaps;
            foreach (var (carConfiguration, doNeedPitStop) in from carConfiguration in carConfigurations
                                                              let totalFuelForRaceCompletion = (carConfiguration.AverageFuelPerLap * totalRaceDistance) / raceTrack.LapDistance
                                                              let doNeedPitStop = carConfiguration.FuelCapacity < totalFuelForRaceCompletion
                                                              select (carConfiguration, doNeedPitStop))
            {
                if (doNeedPitStop)
                {
                    double timeToCompleteRaceWithPitStop = GetTimeToCompleteRaceWithPitStop(raceTrack, carConfiguration, totalRaceDistance);
                    var carConfigurationRank = new RaceCompletionResult { CarConfiguration = carConfiguration, RaceCompletionTime = (int)timeToCompleteRaceWithPitStop };
                    carConfigurationRanks.Add(carConfigurationRank);
                }
                else
                {
                    var timeToCompleteRace = carConfiguration.TimeToCompleteOneLap * raceTrack.NoOfLaps;
                    var carConfigurationRank = new RaceCompletionResult { CarConfiguration = carConfiguration, RaceCompletionTime = timeToCompleteRace };
                    carConfigurationRanks.Add(carConfigurationRank);
                }
            }

            int i = 0;
            return carConfigurationRanks.OrderBy(x => x.RaceCompletionTime).Select(y => (y,++i)).ToList();
        }

        /// <summary>
        /// Gets the time taken to complete race when Pitstop is considered
        /// </summary>
        /// <param name="raceTrack">Race track</param>
        /// <param name="carConfiguration">Car configuration</param>
        /// <param name="totalRaceDistance">Total race distance</param>
        /// <returns>Time to complete race with pit stop in place</returns>
        private double GetTimeToCompleteRaceWithPitStop(RaceTrack raceTrack, CarConfiguration carConfiguration, int totalRaceDistance)
        {
            var totalPitStops = (double)(totalRaceDistance / carConfiguration.FuelCapacity);
            var totalPitStopsToMakeForRace = Math.Ceiling(totalPitStops);
            var totalTimeToMakePitStop = totalPitStopsToMakeForRace * raceTrack.TimeToMakePitStop;
            var timeSpentInPitStop = PitStopTime * totalPitStopsToMakeForRace;
            var totalPitStop = totalTimeToMakePitStop + timeSpentInPitStop;
            var timeToCompleteRace = carConfiguration.TimeToCompleteOneLap * raceTrack.NoOfLaps;
            var timeToCompleteRaceWithPitStop = timeToCompleteRace + totalPitStop;
            return timeToCompleteRaceWithPitStop;
        }
    }

}
