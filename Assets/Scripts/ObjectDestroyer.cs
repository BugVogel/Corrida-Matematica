using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{


    private Camera camera;

    private void Start()
    {

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }


    private void Update()
    {

       

        if(camera.WorldToViewportPoint(this.transform.position).x < -0.5f )
        {
            Destroy(this.gameObject);
        }

    }



}
