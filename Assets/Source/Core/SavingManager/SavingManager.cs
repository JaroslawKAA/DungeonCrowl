using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using Source.Actors.Characters;
using UnityEngine;

namespace Source.Core.SavingManager
{
    public class SavingManager : MonoBehaviour
    {
        public static SavingManager Singleton { get; private set; }

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;
        }

        private void Start()
        {
            // TODO Remove this, it's for testing
            var json = JsonUtility.ToJson(GenerateSave());
            Debug.Log(json);    
        }

        public Save GetSave()
        {
            return GenerateSave();
        }

        private Save GenerateSave()
        {
            Save save = new Save();
            // Save player data
            save.player = GeneratePlayerSaveData();
            
            // Save characters states
            save.characters = GenerateCharactersSaveData();
            
            // Save items states
            save.items = GenerateItemsSaveData();

            return save;
        }

        private List<CharactersSaveData> GenerateCharactersSaveData()
        {
            // Get items in scene and fill list by CharacterSaveData objects
            List<CharactersSaveData> charactersList = new List<CharactersSaveData>();
            
            var charactersObjects = GameObject.FindGameObjectsWithTag("Character");
            foreach (var characterObject in charactersObjects)
            {
                Character character = characterObject.GetComponent<Character>();
                CharactersSaveData characterSaveData = new CharactersSaveData(character);
                charactersList.Add(characterSaveData);
            }

            return charactersList;
        }

        private List<ItemsSaveData> GenerateItemsSaveData()
        {
            // Get items in scene and fill list by ItemSaveData objects
            
            var itemsObjects = GameObject.FindGameObjectsWithTag("Item");
            List<ItemsSaveData> itemsList = new List<ItemsSaveData>();
            
            foreach (var itemObject in itemsObjects)
            {
                Item item = itemObject.GetComponent<Item>();
                ItemsSaveData itemsSaveData = new ItemsSaveData(item);
                itemsList.Add(itemsSaveData);
            }

            return itemsList;
        }

        private PlayerSaveData GeneratePlayerSaveData()
        {
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            Player player = playerGameObject.GetComponent<Player>();
            PlayerSaveData playerData = new PlayerSaveData(player);
            return playerData;
        }
    }
}