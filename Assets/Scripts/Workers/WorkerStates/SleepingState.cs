using CremboFactory;
using UnityEngine;

namespace Workers.WorkerStates
{
    [CreateAssetMenu(fileName = "SleepingState", menuName = "Crembo Factory / Workers / Sleeping State")]
    public class SleepingState : State
    {
        [SerializeField] private Sprite sleepingSprite;
        
        public override void Enter()
        {
            MessagingSystem.SetWorkerSprite?.Invoke(sleepingSprite);
        }

        public override void Exit()
        {
            
        }
    }
}