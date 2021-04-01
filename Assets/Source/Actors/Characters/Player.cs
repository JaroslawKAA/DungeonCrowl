using System.Runtime.CompilerServices;
using DungeonCrawl.Actors.Items;
using Source.Actors.Items;
using Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            this.Inventory = new Inventory();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Move();
            PickUp();
        }

        private void PickUp()
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.GetComponent<ItemDetector>().Activate();
            }
        }

        public override void Move()
        {
            Vector2 movement = new Vector2();
            float xMovement = 0;
            float yMovement = 0;
            
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // Move up
                yMovement = Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                // Move down
                yMovement = -Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Move left
                xMovement = -Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // Move right
                xMovement = Speed * Time.deltaTime;
            }

            movement.x = xMovement;
            movement.y = yMovement;
            _rb.MovePosition(_rb.position + movement);
        }
        
        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public override string DefaultName => "Player";
        
        public bool CheckIfOwnKey(Key key)
        {
            foreach (Item item in this.Inventory.Content)
            {
                if (item is Key && item == key)
                {
                    MessageBox.Singleton.DisplayMessage("Correct key!");
                    return true;
                }
            }
            MessageBox.Singleton.DisplayMessage("Wrong key!");
            return false;
        }
    }
}
