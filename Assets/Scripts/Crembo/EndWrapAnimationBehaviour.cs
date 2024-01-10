using UnityEngine;

namespace CremboFactory
{
    public class EndWrapAnimationBehaviour : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            MessagingSystem.SuccessCremboWrapping?.Invoke();
        }
    }
}