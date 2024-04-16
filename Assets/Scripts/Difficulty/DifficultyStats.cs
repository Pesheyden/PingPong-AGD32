using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DifficultyStats
{
    public abstract class DifficultyStats
    {
        public float BoardSizeMultiplier;
        public float BoardSpeedMultiplier;
        public float BallSizeMultiplier;
        public float BallStartSpeedMultiplier;
        public float BallAccelerationMultiplier;
    }
    public class EasyDifficulty : DifficultyStats
    {
        public EasyDifficulty()
        {
            BoardSizeMultiplier = 1.25f;
            BoardSpeedMultiplier = 0.75f;
            BallSizeMultiplier = 1.25f;
            BallStartSpeedMultiplier = 0.75f;
            BallAccelerationMultiplier = 0.75f;
        }
    }
    public class MediumDifficulty : DifficultyStats
    {
        public MediumDifficulty()
        {
            BoardSizeMultiplier = 1;
            BoardSpeedMultiplier = 1;
            BallSizeMultiplier = 1;
            BallStartSpeedMultiplier = 1;
            BallAccelerationMultiplier = 1;
        }
    }
    public class HardDifficulty : DifficultyStats
    {
        public HardDifficulty()
        {
            BoardSizeMultiplier = 0.75f;
            BoardSpeedMultiplier = 1.25f;
            BallSizeMultiplier = 0.75f;
            BallStartSpeedMultiplier = 1.25f;
            BallAccelerationMultiplier = 1.25f;
        }
    }
}


