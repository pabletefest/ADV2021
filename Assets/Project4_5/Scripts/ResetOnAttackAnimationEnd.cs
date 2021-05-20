using UnityEngine;

namespace Project4_5.Scripts
{
    public class ResetOnAttackAnimationEnd : StateMachineBehaviour
    {
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //Reset Attack float to 0 in order to stop looping attack
            animator.SetFloat("attack", 0);
        }
    }
}
