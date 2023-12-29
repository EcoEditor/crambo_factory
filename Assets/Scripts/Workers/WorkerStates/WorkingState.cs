using CremboFactory;
using UnityEngine;

namespace Workers.WorkerStates
{
    [CreateAssetMenu(fileName = "WorkingState", menuName = "Crembo Factory / Workers / Working State")]
    public class WorkingState : State
    {
        [SerializeField] private string workStateAnimationTrigger;
        
        public override void Enter()
        {
            MessagingSystem.SetWorkerAnimationTrigger?.Invoke(workStateAnimationTrigger);
        }

        public override void Exit()
        {
        }
    }
}