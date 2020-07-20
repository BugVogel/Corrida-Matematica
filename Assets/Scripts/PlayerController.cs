using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private AnimControllerPlayer animController;
    private Rigidbody2D rb;

    [SerializeField]
    private float velocity = 0.06f;

    private float jumpForce = 2.0f;

    private bool gameover = false;

    private bool isPause = false;

    private GameManagerControllerFase gameManager;

    void Start()
    {
        Time.timeScale = 1;

        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<AnimControllerPlayer>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerControllerFase>();

        this.gameover = false;
        this.isPause = false;



    }


    void Update()
    {

        


        if (!gameover && !isPause)
        {
            movePlayer();
           

        }

        if ( transform.position.y < -15.94f && !gameover)
        {
           
            gameManager.gameOver();
        }


      


    }


    public void victory()
    {

        animController.setIdle();
        this.gameover = true;

    }

    public void setPause(bool isPause)
    {
        this.isPause = isPause;
    }


    public float getVelocity()
    {
        return this.velocity;
    }

    public void gameOver()
    {
        this.gameover = true;
        animController.setIdle();

    }

    public void notGameOver()
    {
        this.gameover = false;
        animController.setRun();
    }

    public void movePlayer()
    {

 

        float mult = velocity * Time.deltaTime;
        animController.setRun();

        //transform.Translate(new Vector2(transform.position.x * mult, 0));

        rb.position = new Vector2(rb.position.x + velocity, rb.position.y);




    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(collision.gameObject.tag == "enemy")
        {
            gameManager.gameOver();


        }



    }



}
