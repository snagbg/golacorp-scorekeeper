using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GolaCorp.ScoreKeeper.Domain
{
    public class Game : IAggregateRoot
    {
        [BsonId]
        public Guid GameId { get; set; }

        public List<Frame> Frames { get; set; } = new List<Frame>();

        public List<Player> Players { get; set; } = new List<Player>();

        public void UpdateRollOneScore(RollOneScore rollOneScore)
        {
            var frame = GetFrame(rollOneScore.FrameNumber);
            var playerScore = GetPlayerScore(frame, rollOneScore.PlayerId);
            UpdateRollOne(rollOneScore, playerScore);
            if (frame.FrameNumber > 1 && frame.FrameNumber < 11)
            {
                PlayerScore previousFramePlayerScore = GetPreviousFramePlayerScore(rollOneScore, frame);
                if (previousFramePlayerScore.FirstRoll.WasStrike && playerScore.FirstRoll.WasStrike)
                {
                    previousFramePlayerScore.TotalPoints += 10;
                    playerScore.TotalPoints += previousFramePlayerScore.TotalPoints;
                }
                if (previousFramePlayerScore.SecondRoll.WasSpare)
                {
                    previousFramePlayerScore.TotalPoints += rollOneScore.NumberOfPinsKnockedDown;
                    playerScore.TotalPoints += previousFramePlayerScore.TotalPoints;
                }
            }
            playerScore.TotalPoints += rollOneScore.NumberOfPinsKnockedDown;
        }

        public void UpdateRollTwoScore(RollTwoScore rollTwoScore)
        {
            var frame = GetFrame(rollTwoScore.FrameNumber);
            var playerScore = GetPlayerScore(frame, rollTwoScore.PlayerId);
            UpdateRollTwo(rollTwoScore, playerScore);
            if (frame.FrameNumber > 1 && frame.FrameNumber < 11)
            {
                PlayerScore previousFramePlayerScore = GetPreviousFramePlayerScore(rollTwoScore, frame);
                if (previousFramePlayerScore.FirstRoll.WasStrike)
                {
                    previousFramePlayerScore.TotalPoints += playerScore.FirstRoll.Points + playerScore.SecondRoll.Points;
                    playerScore.TotalPoints += previousFramePlayerScore.TotalPoints;
                }
            }
            playerScore.TotalPoints += rollTwoScore.NumberOfPinsKnockedDown;

        }

        private PlayerScore GetPreviousFramePlayerScore(RollScoreBase playerRollScore, Frame frame)
        {
            var frameIndex = Frames.FindIndex(x => x.FrameId == frame.FrameId);
            var previousFrame = Frames[frameIndex - 1];
            var previousFramePlayerScore = GetPlayerScore(previousFrame, playerRollScore.PlayerId);
            return previousFramePlayerScore;
        }

        private void UpdateRollTwo(RollTwoScore playerRollScore, PlayerScore playerScore)
        {
            playerScore.SecondRoll.Points = playerRollScore.NumberOfPinsKnockedDown;
            playerScore.SecondRoll.WasSpare = playerRollScore.WasSpare;
        }

        private void UpdateRollOne(RollOneScore rollOneScore, PlayerScore playerScore)
        {
            playerScore.FirstRoll.Points = rollOneScore.NumberOfPinsKnockedDown;
            playerScore.FirstRoll.WasStrike = rollOneScore.WasStrike;
        }

        private Frame GetFrame(ushort FrameNumber)
        {
            if (!Frames.Any(x => x.FrameNumber == FrameNumber))
            {
                Frames.Add(new Frame() { FrameNumber = FrameNumber, FrameId = Guid.NewGuid() });
            }
            return Frames.Single(x => x.FrameNumber == FrameNumber);
        }

        private PlayerScore GetPlayerScore(Frame frame, Guid playerId)
        {
            if (!frame.Scores.Any(x => x.PlayerId == playerId))
            {
                frame.Scores.Add(new PlayerScore() { PlayerId = playerId, PlayerScoreId = Guid.NewGuid() });
            }
            return frame.Scores.Single(x => x.PlayerId == playerId);
        }
    }
}
