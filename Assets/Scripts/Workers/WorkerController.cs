using System;
using UnityEngine;
using Workers.WorkerStates;

namespace Workers
{
    public class WorkerController : MonoBehaviour
    {
        [SerializeField] private SleepingState sleepingState;
        [SerializeField] private WorkingState workingState;
        [SerializeField] private WorkerStates.WorkerStates initialState;
        
        private WorkersStateFactory _stateFactory;
        private State _state;

        private void Awake()
        {
            _stateFactory = new WorkersStateFactory(sleepingState, workingState);
            ChangeState(initialState);
        }

        public void ChangeState(WorkerStates.WorkerStates stateType)
        {
            if (_state != null)
            {
                _state.Exit();
                _state = null;
            }

            _state = _stateFactory.Create(stateType);
            _state.Enter();
        } 
    }
}