using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
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
            GenerateSave();
        }

        public Save GetSave()
        {
            return GenerateSave();
        }

        private Save GenerateSave()
        {
            Save save = new Save();
            
            // TODO Save player state
            
            // Save characters states
            save.Characters = generateCharactersSaveDatas();
            // Save items states
            save.Items = GenerateItemsSaveData();

            return save;
        }

        private Dictionary<string, ItemsSaveData> GenerateItemsSaveData()
        {
            // Get items in scene and fill Dictionary by ItemSaveData objects
            
            var itemsObjects = GameObject.FindGameObjectsWithTag("Item");
            Dictionary<string, ItemsSaveData> itemsDictionary = new Dictionary<string, ItemsSaveData>();
            
            foreach (var itemObject in itemsObjects)
            {
                Item item = itemObject.GetComponent<Item>();
                ItemsSaveData itemsSaveData = new ItemsSaveData(itemObject.activeSelf, item.Amount);
                itemsDictionary[item.Id] = itemsSaveData;
            }

            return itemsDictionary;
        }

        private Dictionary<string, CharactersSaveData> generateCharactersSaveDatas()
        {
            var charactersObjects = GameObject.FindGameObjectsWithTag("Character");
            Dictionary<string, CharactersSaveData> chharactersDictionary = new Dictionary<string, CharactersSaveData>();

            foreach (var characterObject in charactersObjects)
            {
                Character character = characterObject.GetComponent<Character>();
                CharactersSaveData charactersSaveData = new CharactersSaveData(characterObject.activeSelf,
                    character.CurrentHealth, character.Position);
                chharactersDictionary[character.Id] = charactersSaveData;
            }

            return chharactersDictionary;
        }
    }
}