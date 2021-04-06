using UnityEngine;

namespace Source.Core.EnemyStateMachine
{
    public class EnemyChaseState : EnemyState
    {
        public EnemyChaseState(GameObject instance) : base(instance)
        {
        }


        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Enter chase state");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (EnemyStateMachine.Opponent == null)
            {
                EnemyStateMachine.CurrentState = EnemyStateMachine.IdleState;
            }
            else
            {
                float distance = Vector2.Distance(Instance.transform.position,
                    EnemyStateMachine.Opponent.transform.position);

                if (distance > 1.2f)
                {
                    Enemy.Move(EnemyStateMachine.Opponent.transform.position);
                }
            }
        }
    }
}