using CremboFactory;
using UnityEngine;

namespace Workers.WorkerStates
{
    [CreateAssetMenu(fileName = "SleepingState", menuName = "Crembo Factory / Workers / Sleeping State")]
    public class SleepingState : State
    {
        [SerializeField] private string sleepStateAnimationTrigger;
        
        public override void Enter()
        {
            MessagingSystem.SetWorkerAnimationTrigger?.Invoke(sleepStateAnimationTrigger);
        }

        public override void Exit()
        {
            
        }
    }
}