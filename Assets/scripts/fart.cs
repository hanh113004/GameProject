using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fart : StateMachineBehaviour
{
    movement playerMovement;
    Rigidbody2D rb;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {    
        playerMovement=animator.GetComponent<movement>();
        rb=animator.GetComponent<Rigidbody2D>();
        rb.velocity=new Vector2(0f,rb.velocity.y);
        playerMovement.enabled=false;
   }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("fart");
        playerMovement.enabled=true;
    }

  
}
