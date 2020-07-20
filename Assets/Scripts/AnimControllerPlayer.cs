using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerPlayer : MonoBehaviour
{

    private Animator anim;



    void Start()
    {


        anim = GetComponent<Animator>();
        
    }


    public void setRun()
    {

        anim.SetBool("run", true);
        anim.SetBool("jump", false);


    }

    public void setJump()
    {

        anim.SetBool("jump", true);
        anim.SetBool("run", false);


    }


    public void setIdle()
    {
        anim.SetBool("jump", false);
        anim.SetBool("run", false);
    }

    
}
