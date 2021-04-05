using Source.Core;

namespace Source.Actors.Items
{
    public class Equipment
    {
        private Armor _armor;

        public Armor Armor
        {
            get => _armor;
            set
            {
                _armor = value;
                InventoryManager.Singleton.DisplayEquipment();
            }
        }

        private Helmet _helmet;

        public Helmet Helmet
        {
            get => _helmet;
            set
            {
                _helmet = value;
                InventoryManager.Singleton.DisplayEquipment();
            }
        }

        private Weapon _weapon;

        public Weapon Weapon
        {
            get => _weapon;
            set
            {
                _weapon = value;
                InventoryManager.Singleton.DisplayEquipment();
            }
        }
    }
}