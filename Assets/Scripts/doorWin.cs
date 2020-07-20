using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorWin : MonoBehaviour
{


    private GameManagerControllerFase gameManager;


    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerControllerFase>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            gameManager.victory();

        }


    }


}
