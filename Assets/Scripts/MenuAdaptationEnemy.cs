using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAdaptationEnemy : MonoBehaviour
{


    private bool desce = true;
    private bool sobe = false;


    [SerializeField]
    private float velocity = 8f;

    [SerializeField]
    private float sobeVelocity = 0.5f;

    [SerializeField]
    private float positionxDown;

    [SerializeField]
    private float positionyDown;


    [SerializeField]
    private float positionxUp;

    [SerializeField]
    private float positionyUp;

    private bool stop = false;


    private GameManagerControllerFase gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerControllerFase>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!stop) {
            if (transform.position.y > positionyDown && desce)
            {

                float mul = velocity * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(positionxDown, positionyDown, transform.position.z), mul);

            }
            else
            {
                desce = false;
                sobe = true;
                velocity = sobeVelocity;
            }


            if (transform.position.y < positionyUp && sobe)
            {
                float mul = velocity * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, new Vector3(positionxUp, positionyUp, transform.position.z), mul);


            }
            else
            {
                sobe = false;
                desce = true;
                velocity = 8f;
            }

           
        }



    }


    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        stop = true;


        if(collision.gameObject.tag == "Player")
        {
            gameManager.gameOver();
        }

    }

}
