using UnityEngine;

namespace Source.Core.EnemyStateMachine
{
    public class EnemyStateMachine : StateMachine
    {
        private IState IdleState { get; set; }
        private IState PatrolState { get; set; }
        private IState ChaseState { get; set; }
        private IState AttackState { get; set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            IdleState = new EnemyIdleState(gameObject);
            PatrolState = new EnemyPatrolState(gameObject);
            ChaseState = new EnemyChaseState(gameObject);
            AttackState = new EnemyAttackState(gameObject);

            CurrentState = IdleState;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            CurrentState.OnUpdate();
        }
    }
}
