using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    float timer=0;
    [SerializeField] Animator anim;
    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        anim.SetBool("bounce",true);
    }
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=0.4f) {
            anim.SetBool("bounce",false);
            timer = 0f;
        }
    }
}
