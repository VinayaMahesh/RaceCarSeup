using FluentAssertions;
using NUnit.Framework;
using RaceCarSetup;
using System.Collections.Generic;
using System.Linq;

namespace RaceCarSetupTests
{
    public class RaceCarSetupTest
    {

        [Test]
        [Description("Test for validating the ranking of car configuration by race compeltion time for particular race track")]
        public void RaceCarConfigurationsTest()
        {
            var raceTrack = new RaceTrack { LapDistance = 10, NoOfLaps = 7, TimeToMakePitStop = 10 };
            var carConfigurations = new List<CarConfiguration>();
            carConfigurations.Add(new CarConfiguration { AverageFuelPerLap = 5, FuelCapacity = 50, TimeToCompleteOneLap = 5 });
            carConfigurations.Add(new CarConfiguration { AverageFuelPerLap = 6, FuelCapacity = 40, TimeToCompleteOneLap = 6 });
            carConfigurations.Add(new CarConfiguration { AverageFuelPerLap = 4, FuelCapacity = 30, TimeToCompleteOneLap = 4 });


            var raceCarSetup = new RaceCarBusiness();
            var testCarConfigurationsRanks = GetCarConfigurationRanks();
            var carConfigurationsByRank = raceCarSetup.GetCarConfigurationsByRaceTime(carConfigurations, raceTrack);


            carConfigurationsByRank.Should().NotBeNullOrEmpty().And.BeOfType<List<(RaceCompletionResult, int)>>();
            //Asserting if the order of race completion time is in ascending order
            carConfigurationsByRank.Select(x => x.CarConfig.RaceCompletionTime).Should().ContainInOrder(28, 35, 53);
            //Asserting the car configuration by rank
            carConfigurationsByRank.Select(x => x.Rank).Should().ContainInOrder(1, 2, 3);
            carConfigurationsByRank.Should().HaveCount(3);
            //Asserting expected Car Configuration with actual
            carConfigurationsByRank.Select(x=>x.CarConfig).Should().BeEquivalentTo(testCarConfigurationsRanks);
        }


        /// <summary>
        /// Helper method for getting test data
        /// </summary>
        /// <returns></returns>
        private RaceCompletionResult[] GetCarConfigurationRanks()
        {
            var carConfigurationRanks = new List<RaceCompletionResult>();
            carConfigurationRanks.Add(new RaceCompletionResult
            {
                CarConfiguration = new CarConfiguration { AverageFuelPerLap = 5, FuelCapacity = 50, TimeToCompleteOneLap = 5 },
                RaceCompletionTime = 35
            });
            carConfigurationRanks.Add(new RaceCompletionResult
            {
                CarConfiguration = new CarConfiguration { AverageFuelPerLap = 4, FuelCapacity = 30, TimeToCompleteOneLap = 4 },
                RaceCompletionTime = 28
            });

            carConfigurationRanks.Add(new RaceCompletionResult
            {
                CarConfiguration = new CarConfiguration { AverageFuelPerLap = 6, FuelCapacity = 40, TimeToCompleteOneLap = 6 },
                RaceCompletionTime = 53
            });

            return carConfigurationRanks.ToArray();
        }
    }
}
