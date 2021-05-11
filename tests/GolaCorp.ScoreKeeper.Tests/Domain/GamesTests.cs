using GolaCorp.ScoreKeeper.Domain;
using System;
using Xunit;
using Shouldly;
using System.Linq;

namespace GolaCorp.ScoreKeeper.Tests
{
    public class GamesTests
    {
        [Fact]
        public void Can_Update_Game_Score_For_FrameOne_RollOne()
        {
            //Arrange
            ushort numberOfPinsKnowkedDown = 4;
            var game = new Game();
            var playerScore = new RollOneScore()
            {
                NumberOfPinsKnockedDown = numberOfPinsKnowkedDown,
                FrameNumber = 1
            };

            //Act
            game.UpdateRollOneScore(playerScore);

            //Assert
            game.Frames.First().Scores.First().FirstRoll.Points.ShouldBe(numberOfPinsKnowkedDown);

        }

        [Fact]
        public void Can_Update_Game_Score_For_FrameOne_RollTwo()
        {
            //Arrange
            ushort numberOfPinsKnowkedDown = 8;
            var game = new Game();
            var playerScore = new RollTwoScore()
            {                
                NumberOfPinsKnockedDown = numberOfPinsKnowkedDown,
                FrameNumber = 1
            };

            //Act
            game.UpdateRollTwoScore(playerScore);

            //Assert
            game.Frames.First().Scores.First().SecondRoll.Points.ShouldBe(numberOfPinsKnowkedDown);
        }

        [Fact]
        public void Can_Update_Game_Score_For_FrameOne()
        {
            //Arrange
            ushort numberOfPinsKnowkedDownInRollOne = 7;
            ushort numberOfPinsKnowkedDownInRollTwo = 1;
            var game = new Game();
            var rollOneScore = new RollOneScore()
            {               
                NumberOfPinsKnockedDown = numberOfPinsKnowkedDownInRollOne,
                FrameNumber = 1
            };

            var rollTwoScore = new RollTwoScore()
            {
                NumberOfPinsKnockedDown = numberOfPinsKnowkedDownInRollTwo,
                FrameNumber = 1
            };

            //Act
            game.UpdateRollOneScore(rollOneScore);
            game.UpdateRollTwoScore(rollTwoScore);

            //Assert
            game.Frames.First().Scores.First().TotalPoints.ShouldBe(numberOfPinsKnowkedDownInRollOne + numberOfPinsKnowkedDownInRollTwo);
        }

        [Fact]
        public void Can_Update_Game_Score_For_FrameTwo()
        {
            //Arrange            
            var game = new Game();
            var rollOneScore = new RollOneScore()
            {
                NumberOfPinsKnockedDown = 7,
                FrameNumber = 1
            };
            var rollTwoScore = new RollTwoScore()
            {
                NumberOfPinsKnockedDown = 3,
                FrameNumber = 1,
                WasSpare  = true
                
            };
            game.UpdateRollOneScore(rollOneScore);
            game.UpdateRollTwoScore(rollTwoScore);

            rollOneScore.FrameNumber = 2;
            rollTwoScore.FrameNumber = 2;
            rollTwoScore.WasSpare = false;
            rollTwoScore.NumberOfPinsKnockedDown = 1;


            //Act
            game.UpdateRollOneScore(rollOneScore);
            game.UpdateRollTwoScore(rollTwoScore);

            //Assert            
            game.Frames.Single(x => x.FrameNumber == 1).Scores.First().TotalPoints.ShouldBe(17);
            game.Frames.Single(x=>x.FrameNumber == 2).Scores.First().TotalPoints.ShouldBe(25);

        }

        [Fact]
        public void Can_Update_Game_Score_For_FrameTwo_When_FrameOne_WasStrike()
        {
            //Arrange            
            var game = new Game();
            var rollOneScore = new RollOneScore()
            {
                NumberOfPinsKnockedDown = 10,
                FrameNumber = 1,
                WasStrike = true
                
            };
            var rollTwoScore = new RollTwoScore()
            {
                NumberOfPinsKnockedDown = 3,
                FrameNumber = 1               
            };

            game.UpdateRollOneScore(rollOneScore);           

            rollOneScore.FrameNumber = 2;
            rollTwoScore.FrameNumber = 2;
            rollOneScore.WasStrike = false;
            rollOneScore.NumberOfPinsKnockedDown = 8;
            rollTwoScore.NumberOfPinsKnockedDown = 1;


            //Act
            game.UpdateRollOneScore(rollOneScore);
            game.UpdateRollTwoScore(rollTwoScore);

            //Assert            
            game.Frames.Single(x => x.FrameNumber == 1).Scores.First().TotalPoints.ShouldBe(19);
            game.Frames.Single(x => x.FrameNumber == 2).Scores.First().TotalPoints.ShouldBe(28);

        }
    }
}
