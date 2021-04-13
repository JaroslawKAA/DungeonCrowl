using System.Collections.Generic;

namespace Source.Core.SavingManager
{
    public class Save
    {
        public PlayerSaveData Player { get; set; }
        public Dictionary<string, CharactersSaveData> Characters { get; set; }
        public Dictionary<string, ItemsSaveData> Items { get; set; }
    }
}