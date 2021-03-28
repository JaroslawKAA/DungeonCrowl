using UnityEngine;

namespace DungeonCrawl.Actors
{
    public interface ISelectable
    {
        public void Activate(GameObject owner);
    }
}