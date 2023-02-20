using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfidle : StateMachineBehaviour
{
    float timer = 0f;
    float rand = 0f;
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0,4);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   timer+=Time.deltaTime;
        
        if(timer>=3f) 
            {
                if(rand<=1) animator.SetTrigger("bite");
                if(rand<=2&&rand>1) animator.SetTrigger("hook");
                if(rand<=3&&rand>2) animator.SetTrigger("scratch");
                timer=0;
            }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
