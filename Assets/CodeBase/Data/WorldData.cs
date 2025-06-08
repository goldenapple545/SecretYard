using System;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public Vector3Data position;
        public PositionOnLevel positionOnLevel;

        public WorldData() {}

        public WorldData(string initialLevel)
        {
            positionOnLevel = new PositionOnLevel(initialLevel);
        }

        public override string ToString()
        {
            return $"positionOnLevel: {positionOnLevel}";
        }
    }
}
