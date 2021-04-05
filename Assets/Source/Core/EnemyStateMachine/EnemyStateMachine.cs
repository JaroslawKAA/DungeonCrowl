using UnityEngine;

namespace Source.Core.EnemyStateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : StateMachine
    {
        public EnemyIdleState IdleState { get; set; }
        public EnemyPatrolState PatrolState { get; set; }
        public EnemyChaseState ChaseState { get; set; }
        public EnemyAttackState AttackState { get; set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            IdleState = new EnemyIdleState(gameObject);
            PatrolState = new EnemyPatrolState(gameObject);
            ChaseState = new EnemyChaseState(gameObject);
            AttackState = new EnemyAttackState(gameObject);

            IdleState.OnAwake();
            PatrolState.OnAwake();
            ChaseState.OnAwake();
            AttackState.OnAwake();
            
            CurrentState = IdleState;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            CurrentState.OnUpdate();
        }
    }
}
