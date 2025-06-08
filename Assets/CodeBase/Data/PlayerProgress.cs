using System;
using Newtonsoft.Json;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData worldData;

        public PlayerProgress() { }

        public PlayerProgress(string initialLevel)
        {
            worldData = new WorldData(initialLevel);
        }

        public override string ToString()
        {
            return $"WorldData: {worldData}";
        }
    }
}
