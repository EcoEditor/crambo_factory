using CremboFactory;
using UnityEngine;

namespace Workers.WorkerStates
{
    [CreateAssetMenu(fileName = "WorkingState", menuName = "Crembo Factory / Workers / Working State")]
    public class WorkingState : State
    {
        [SerializeField] private string workStateAnimationBool = "IsSleeping";
        
        public override void Enter(WorkerController workerController)
        {
            MessagingSystem.SetWorkerAnimationBool?.Invoke(workerController.WorkerIndex, workStateAnimationBool, false);
        }

        public override void Exit()
        {
        }
    }
}