using CremboFactory;
using UnityEngine;

namespace Workers.WorkerStates
{
    [CreateAssetMenu(fileName = "WorkingState", menuName = "Crembo Factory / Workers / Working State")]
    public class WorkingState : State
    {
        [SerializeField] private Sprite workStateSprite;
        
        public override void Enter()
        {
            MessagingSystem.SetWorkerSprite?.Invoke(workStateSprite);
        }

        public override void Exit()
        {
        }
    }
}