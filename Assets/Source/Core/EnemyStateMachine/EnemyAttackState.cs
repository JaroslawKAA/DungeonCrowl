using System.Collections;
using System.Collections.Generic;
using DungeonCrawl;
using DungeonCrawl.Actors.Characters;
using Source.Actors;
using UnityEngine;

namespace Source.Core.EnemyStateMachine
{
    public class EnemyAttackState : EnemyState
    {
        public float Timer { get; set; }
        public EnemyAttackState(GameObject instance) : base(instance)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Timer = Enemy.attackDelay;
            
            Debug.Log($"{Enemy.name} - Enter Attack state.");
            Enemy.CurrentState = CharacterState.Attack;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (EnemyStateMachine.DistanceToOpponent > 1.4f)
            {
                if (EnemyStateMachine.Opponent != null)
                    EnemyStateMachine.CurrentState = EnemyStateMachine.ChaseState;
                else
                    EnemyStateMachine.CurrentState = EnemyStateMachine.IdleState;
            }

            if (Timer >= 0)
                Timer -= Time.deltaTime;
            else
            {
                SetAttackSprite();
                EnemyStateMachine.Opponent.GetComponent<Character>().ApplyDamage(Enemy.Attack);
                Timer = Enemy.attackDelay;
            }
        }
        /// <summary>
        /// Set attack sprite and after 0.5 s. return idle sprite.
        /// </summary>
        public void SetAttackSprite()
        {
            SpriteRenderer sr = Enemy.gameObject.GetComponent<SpriteRenderer>();
            
            sr.sprite = Enemy.AttackSprite;
            sr.flipX = false;
            sr.flipY = false;
            
            Enemy.gameObject.GetComponent<FlippingSprite>().enabled = false;
            
            IEnumerator coroutine = ReturnIdleSprite();
            EnemyStateMachine.RunCoroutine(coroutine);
        }
        private IEnumerator ReturnIdleSprite()
        {
            yield return new WaitForSeconds(0.5f);
            
            SpriteRenderer sr = Enemy.gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = Enemy.IdleSprite;
            Enemy.gameObject.GetComponent<FlippingSprite>().enabled = true;
        }
    }
}