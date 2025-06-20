﻿using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string level;
        public Vector3Data position;

        public PositionOnLevel()
        {}
        public PositionOnLevel(string level, Vector3Data position)
        {
            this.level = level;
            this.position = position;
        }

        public PositionOnLevel(string initialLevel)
        {
            this.level = initialLevel;
        }

        public override string ToString()
        {
            return $"position: {position}";
        }
    }
}
