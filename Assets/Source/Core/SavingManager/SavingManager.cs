using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Items;
using UnityEngine;
using System.IO;
using DungeonCrawl.Actors.Characters;


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

            // TODO Save characters states

            // Save items states
            save.Items = GenerateItemsSaveData();
            save.Characters = GenerateCharacterSaveData();

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
        
        private Dictionary<string, CharactersSaveData> GenerateCharacterSaveData()

        {
            var charactersObject = GameObject.FindGameObjectsWithTag("Character");
            Dictionary<string, CharactersSaveData> charcetrsDictionary = new Dictionary<string, CharactersSaveData>();

            foreach (var characterObject in charactersObject)
            {
                Character character = characterObject.GetComponent<Character>();
                CharactersSaveData charactersSaveData = new CharactersSaveData(characterObject.activeSelf, character.CurrentHealth, character.Position);
                charcetrsDictionary[character.Id] = charactersSaveData;
            }

            return new Dictionary<string, CharactersSaveData>();



        }
            

       
        // Position[0] = character.transform.position.x;
        // Position[1] = character.transform.position.y;
        // Position[2] = character.transform.position.z;
        

       
    }
}

