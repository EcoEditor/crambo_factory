using CremboFactory;
using UnityEngine;

namespace Workers.WorkerStates
{
    [CreateAssetMenu(fileName = "SleepingState", menuName = "Crembo Factory / Workers / Sleeping State")]
    public class SleepingState : State
    {
        [SerializeField] private string sleepStateAnimationBool;
        
        public override void Enter(WorkerController workerController)
        {
            MessagingSystem.SetWorkerAnimationBool?.Invoke(workerController.WorkerIndex, sleepStateAnimationBool, true);
        }

        public override void Exit()
        {
            
        }
    }
}