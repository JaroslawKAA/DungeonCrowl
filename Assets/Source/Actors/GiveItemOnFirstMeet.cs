using DungeonCrawl.Actors.Characters;
using UnityEngine;

namespace Source.Actors
{
    [RequireComponent(typeof(NPC))]
    public class GiveItemOnFirstMeet : MonoBehaviour
    {
        public GameObject itemToGive;

        public void GivItem()
        {
            itemToGive.SetActive(true);
            Destroy(gameObject.GetComponent<GiveItemOnFirstMeet>());
        }
    }
}
