using CremboFactory;
using UnityEngine;
using Workers.WorkerStates;

namespace Workers
{
    public class WorkerController : MonoBehaviour
    {
        [SerializeField] private int workerIndex;
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
            MessagingSystem.SetWorkerAnimationBool += SetWorkerAnimationBool;
            MessagingSystem.SetWorkerAnimationTrigger += SetWorkerAnimationTrigger;
            MessagingSystem.WakeupWorker += OnWakeupWorker;
            ChangeState(initialState);
        }

        private void OnDestroy()
        {
            MessagingSystem.SetWorkerAnimationBool -= SetWorkerAnimationBool;
            MessagingSystem.SetWorkerAnimationTrigger -= SetWorkerAnimationTrigger;
            MessagingSystem.WakeupWorker -= OnWakeupWorker;
        }
        
        private void SetWorkerAnimationTrigger(int index, string triggerName)
        {
            if (workerIndex == index)
            {
                animator.SetTrigger(triggerName);
            }
        }
        
        private void OnWakeupWorker(int index)
        {
            if (workerIndex == index)
            {
                ChangeState(WorkerStates.WorkerStates.Working);
            }
        }


        private void SetWorkerAnimationBool(int index, string boolName, bool isSleeping)
        {
            if (workerIndex == index)
            {
                animator.SetBool(boolName, isSleeping);
            }
        }

        public void ChangeState(WorkerStates.WorkerStates stateType)
        {
            if (_state != null)
            {
                _state.Exit();
                _state = null;
            }

            _state = _stateFactory.Create(stateType);
            _state.Enter(this);
            Debug.Log($"Changed to state {stateType}");
        }

        public State MyState => _state;
        public int WorkerIndex => workerIndex;
    }
}