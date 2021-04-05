using System;
using Source.Core.EnemyStateMachine;
using UnityEngine;

namespace Source.Core
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected IState CurrentState;

        private void Awake()
        {
            OnAwake();
        }

        private void Update()
        {
            OnUpdate();
        }

        protected virtual void OnAwake()
        {
        }

        protected virtual void OnUpdate()
        {
        }
    }
}