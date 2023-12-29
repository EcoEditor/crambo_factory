using CremboFactory;
using UnityEngine;
using Workers.WorkerStates;

namespace Workers
{
    public class WorkerController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer stateSpriteRenderer;
        [SerializeField] private SleepingState sleepingState;
        [SerializeField] private WorkingState workingState;
        [SerializeField] private WorkerStates.WorkerStates initialState;
        [SerializeField] private Animator animator;
        
        private WorkersStateFactory _stateFactory;
        private State _state;

        private void Awake()
        {
            _stateFactory = new WorkersStateFactory(sleepingState, workingState);
            MessagingSystem.SetWorkerAnimationTrigger += SetWorkerSprite;
            ChangeState(initialState);
        }

        private void OnDestroy()
        {            
            MessagingSystem.SetWorkerAnimationTrigger -= SetWorkerSprite;
        }

        private void SetWorkerSprite(string triggerName)
        {
            animator.SetTrigger(triggerName);
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

        public State MyState => _state;
    }
}