using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{  
    [SerializeField] Animator anim;
    [SerializeField] movement playerMovement;
    [SerializeField] SpriteRenderer bossWolfArm;
    float countHurtTime=0f;
    void Start()
    {   
        playerMovement=gameObject.GetComponent<movement>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
            Debug.Log("hi");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="enemy" && playerMovement.OnEnemy())
           {countHurtTime+=1;
            if(countHurtTime>=20) anim.SetBool("phase2",true);
            anim.SetTrigger("hurt");
            playerMovement.Jump();
            Debug.Log(countHurtTime);
           }
    }
 
}
