using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAdaptationMenuSub : MonoBehaviour
{





    private float velocity = 8f;

    [SerializeField]
    private GameObject numResult;


    [SerializeField]
    private GameObject tile1;

    [SerializeField]
    private GameObject tile2;

    [SerializeField]
    private GameObject tile3;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            Destroy(tile1);
            Destroy(tile2);
            Destroy(tile3);
            Destroy(numResult);
           





        }




    }



}
