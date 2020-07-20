using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerControllerFase : MonoBehaviour
{

    [SerializeField]
    private Text score;
    [SerializeField]
    private Image pauseOption;
    [SerializeField]
    private Sprite pause;
    [SerializeField]
    private Sprite play;
    private int operacoesCorretas = 0;
    private bool isPause = false;

    [SerializeField]
    private GameObject player;

    private AudioSource music;

    private PlayerController playerController;

    [SerializeField]
    private Sprite soundOn;

    [SerializeField]
    private Image soundImg;
    [SerializeField]
    private Sprite soundOff;
    [SerializeField]
    private GameObject menu;


    [SerializeField]
    private GameObject menuGameOver;

    [SerializeField]
    private GameObject menuWin;


    [SerializeField]
    private AudioSource winMusic;

    [SerializeField]
    private AudioSource winEffect;

    [SerializeField]
    private AudioSource gameOverEffect;

    [SerializeField]
    private AudioSource gameOverMusic;

    [SerializeField]
    private AudioSource correctAnswerEffect;

    
    

    


    private bool gameover = false;



    void Start()
    {

        
        pauseOption.sprite = pause;
        score.text = "Operações realizadas: " + operacoesCorretas;

        music = GetComponent<AudioSource>();

        playerController = player.GetComponent<PlayerController>();



        if (GameManagerControllerMenu.somActive)
        {
            music.Play();

            soundImg.sprite = soundOn;
        }
        else
        {

            soundImg.sprite = soundOff;
        }

    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !this.gameover) //Faz pausa no jogo
        {
            pauseController();

        }
        
    }


    public void pauseController()
    {
         
         

        if (isPause) //Deu play
        {
            isPause = false;
            Time.timeScale = 1;
            pauseOption.sprite = pause;
            playerController.setPause(false);
            menu.SetActive(false);
            music.Play();


        }
        else //Deu pause
        {
            isPause = true;
            Time.timeScale = 0;
            pauseOption.sprite = play;
            playerController.setPause(true);
            menu.SetActive(true);
            music.Pause();


        }

        
    }


    public void playGame()
    {
        Time.timeScale = 1;
        isPause = false;
        playerController.setPause(false);
        menu.SetActive(false);
        pauseOption.sprite = pause;
        music.Play();
    }


    public void goToMenu()
    {
        Time.timeScale = 1;
        isPause = false;
        playerController.setPause(false);
        menu.SetActive(false);
        pauseOption.sprite = pause;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Inicial");

    }


    public void exitGame()
    {
        Application.Quit();
    }




    public void addOpCorreta()
    {

        operacoesCorretas++;
        correctAnswerEffect.Play();
        score.text = "Operações realizadas: " + operacoesCorretas;

    }



    public void changeSound()
    {


        GameManagerControllerMenu.somActive = !GameManagerControllerMenu.somActive;

        if (GameManagerControllerMenu.somActive)
        {
            soundImg.sprite = soundOn;
        }
        else
        {
            soundImg.sprite = soundOff;
        }


        if (music.isPlaying && !GameManagerControllerMenu.somActive)
        {

            music.Pause();
        }
        else if (!music.isPlaying && GameManagerControllerMenu.somActive)
        {
            music.Play();
        }

    }


    public void gameOver()
    {
        music.Pause();
        gameOverEffect.Play();
        gameOverMusic.Play();
        isPause = true;
        Time.timeScale = 0;
        pauseOption.gameObject.SetActive(false);
        soundImg.gameObject.SetActive(false);
        playerController.setPause(true);
        playerController.gameOver();
        menuGameOver.SetActive(true);//Menu de gameOver
        this.gameover = true;



    }


    public void restart()
    {

        Time.timeScale = 1;
        isPause = false;
        playerController.setPause(false);
        playerController.notGameOver();
        menuGameOver.SetActive(false);
        pauseOption.gameObject.SetActive(true);
        soundImg.gameObject.SetActive(true);
        pauseOption.sprite = pause;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }



    public void victory()
    {
        
        music.Stop();
        winEffect.Play();
        winMusic.Play();
        playerController.victory();
        menuWin.SetActive(true);
        pauseOption.gameObject.SetActive(false);
        soundImg.gameObject.SetActive(false);






    }




}
