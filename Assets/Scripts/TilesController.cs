using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{



    [SerializeField]
    private GameObject operatorMode;

    [SerializeField]
    private Material blue;

    private float locationx = 0;
    private float locationy = 0;
    private float velocity = 8f;
    private int value;
    private bool isBlocking = true;

    private bool isWall = false;

    private Material initialMaterial;

    bool moveTo = false;

    private OperationController opController;

    private GameManagerControllerFase gameManager;


    private void Start()
    {

        initialMaterial = GetComponent<Renderer>().material;
    

        opController = operatorMode.GetComponent<OperationController>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerControllerFase>();


        switch (this.gameObject.tag)
        {

            case "Um": value = 1;
                break;

            case "Dois": value = 2;
                break;

            case "Tres": value = 3;
                break;

            case "Quatro": value = 4;
                break;

            case "UmWall": value = 1; isWall = true;
                break;

            case "DoisWall": value = 2; isWall = true;
                break;

            case "TresWall": value = 3; isWall = true;
                break;

            case "QuatroWall": value = 4; isWall = true;
                break;




        }


    }



    private void Update()
    {

        if (moveTo)
        {
            float mul = velocity * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(locationx, locationy, transform.position.z), mul);
        }

    }

    public void isNotBlocking()
    {
        this.isBlocking = false;
    }

    private void OnMouseDown()
    {
        opController.doOperation(value, this.gameObject);

        
  

    }

    public void paintBlue()
    {
        GetComponent<Renderer>().material = blue;

        foreach (Transform child in transform)
        {
            if (child.tag != "Untagged")
                child.gameObject.GetComponent<Renderer>().material = blue;

        }
    }


    public IEnumerator removeBlue(int delay) {



        yield return new WaitForSeconds(delay);


        GetComponent<Renderer>().material = initialMaterial;

      

        foreach (Transform child in transform)
        {
            if (child.tag != "Untagged")
                child.gameObject.GetComponent<Renderer>().material = initialMaterial;

        }

       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (isWall && isBlocking)
        {

            if (collision.gameObject.tag == "Player") //Bateu na parede, perde
            {

                GameObject player = collision.gameObject;
                PlayerController controllerPlayer = player.GetComponent<PlayerController>();
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                
                player.transform.rotation = new Quaternion(player.transform.rotation.x,player.transform.rotation.y, player.transform.rotation.z+0.4f,player.transform.rotation.w);
                rb.AddForce(new Vector2(-0.02f, 0));
                gameManager.gameOver();

            }


        }

    }



    public void setLocationX(float locationx)
    {
        this.locationx = locationx;
    }

    public void setLocaltionY(float locationy)
    {
        this.locationy = locationy;
    }



    public void move()
    {
        moveTo = true;


        StartCoroutine(removeBlue(1));
        
    }



    public void destroy()
    {
        Destroy(GetComponent<GameObject>());
    }






}
