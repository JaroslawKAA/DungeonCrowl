

namespace Source.Core.SavingManager
{
    public class ItemsSaveData
    {
        public bool Enabled;
        public int Amount;

        public ItemsSaveData(bool enabled, int amount)
        {
            Enabled = enabled;
            Amount = amount;
        }
     
    }
}