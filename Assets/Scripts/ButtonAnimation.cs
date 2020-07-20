using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{


    private Animator anim;


    

    private void Start()
    {

        anim = GetComponent<Animator>();
        
    }


   

    public void bigButton()
    {
       

        anim.SetBool("mouseOver", true);
        anim.SetBool("mouseOut", false);

      
        


    }


    public void smallButton()
    {

        anim.SetBool("mouseOut", true);
        anim.SetBool("mouseOver", false);


     
    }


}
