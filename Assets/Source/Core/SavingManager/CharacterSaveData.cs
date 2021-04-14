using System.Collections.Generic;
using System.Numerics;
using DungeonCrawl.Actors.Characters;
using Vector3 = UnityEngine.Vector3;

namespace Source.Core.SavingManager
{
    public class CharactersSaveData
    {
        public bool Enable { get; set; }
        public int CurrentHealth { get; set; }
        // public float[] Position;
        public Vector3 Position { get; set; }

        public CharactersSaveData(bool enable,int currentHealth,Vector3 position)
        {
            Enable = enable;
            CurrentHealth = currentHealth;
            Position = position;
            // Position = new float[3];

        }
    }
}