using UnityEngine;

namespace Source.Core.EnemyStateMachine
{
    public abstract class State : IState
    {
        private GameObject Instance { get; set; }

        public State(GameObject instance)
        {
            Instance = instance;
        }
        public virtual void OnUpdate()
        {
        }
    }
}