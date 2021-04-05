using System;
using Source.Core.EnemyStateMachine;
using UnityEngine;

namespace Source.Core
{
    public abstract class StateMachine : MonoBehaviour
    {
        private IState _currentState;
        public IState CurrentState
        {
            get => _currentState;
            set
            {
                _currentState?.OnExit();
                _currentState = value;
                _currentState.OnEnter();
            }
        }

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