using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using Source.Actors.Items;
using UnityEngine;
// ReSharper disable All

namespace Source.InteractiveItems
{
    public class Door : MonoBehaviour, ISelectable
    {
        [SerializeField] private Sprite _closeSprite;

        public Sprite CloseSprite
        {
            get => _closeSprite; 
            set => _closeSprite = value;
        }

        [SerializeField] private Sprite _openSprite;

        public Sprite OpenSprite
        {
            get => _openSprite;
            set => _openSprite = value;
        }

        private SpriteRenderer _spriteRenderer;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = CloseSprite;
        }

        private bool _isLock = false;

        public bool IsLock
        {
            get => _isLock;
            set => _isLock = value;
        }

        private bool _isOpen = false;

        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }

        private Key _key;

        private Key Key
        {
            get => _key;
            set => _key = value;
        }

        public void Open()
        {
            IsOpen = true;
            _spriteRenderer.sprite = OpenSprite;
            GetComponent<Collider2D>().isTrigger = true;
            // TODO Play sound.
        }

        public void Close()
        {
            IsOpen = false;
            _spriteRenderer.sprite = CloseSprite;
            GetComponent<Collider2D>().isTrigger = false;
            // TODO Play sound.
        }

        public void Unlock()
        {
            GameObject player = GameObject.FindWithTag("Player");
            Player p = player.GetComponent<Player>();
            if (Player.CheckIfOwnKey(this.Key))
            {
                IsLock = true;
                // TODO Play sound
            }
            else
            {
                // TODO Display communicate and play sound
            }
        }

        public void Activate(GameObject owner)
        {
            if (IsLock)
                Unlock();
            else
            {
                if (IsOpen)
                    Close();
                else
                    Open();
            }
        }
    }
}