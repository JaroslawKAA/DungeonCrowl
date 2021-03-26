using DungeonCrawl.Actors.Items;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        private Rigidbody2D _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Move();
        }
        
        public override void Move()
        {
            Vector2 movement = new Vector2();
            float xMovement = 0;
            float yMovement = 0;
            
            
            if (Input.GetKey(KeyCode.W))
            {
                // Move up
                yMovement = Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                // Move down
                yMovement = -Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                // Move left
                xMovement = -Speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
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
        
        public static bool CheckIfOwnKey(Key key)
        {
            // TODO 
            throw new System.NotImplementedException();
        }
    }
}
