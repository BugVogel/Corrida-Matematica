using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerControllerMenu : MonoBehaviour
{


    public static bool[] operations =  { true, false, false, false }; //Operações a serem realizadas nas fases
    public static bool somActive = true;

    private AudioSource music;

    [SerializeField]
    private Text soundOption;

    [SerializeField]
    private Text[] stateOptions = new Text[4];

    [SerializeField]
    private GameObject popUpNoLevel;

    [SerializeField]
    private GameObject notImplemented;
  


    void Start()
    {


        music = GetComponent<AudioSource>();


        //Ajusta o menu de acordo com as opções salvas

        if ( GameManagerControllerMenu.somActive)
        {
            music.Play();
            if(soundOption!= null)
            soundOption.text = "Ligado";
        }
        else
        {
            if (soundOption != null)
                soundOption.text = "Desligado";
        }

        if (stateOptions[0] != null)
        {

            for (int op = 0; op < GameManagerControllerMenu.operations.Length; op++)
            {
                if (GameManagerControllerMenu.operations[op])
                {
                    stateOptions[op].text = "Ligado";
                }
                else
                {
                    stateOptions[op].text = "Desligado";
                }

            }
        }



    }

   
    public void playGame()
    {

        bool sum = GameManagerControllerMenu.operations[0];
        bool sub = GameManagerControllerMenu.operations[1];
        bool mult = GameManagerControllerMenu.operations[2];
        bool div = GameManagerControllerMenu.operations[3];

        if ( !sum && !sub && !mult && !div) //Seleciona a fase do jogador de acordo com as operações configuradas
        {

            popUpNoLevel.SetActive(true);

        }
        else if(sum && !sub && !mult && !div)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Fase_1_Soma");
        }
        else if(!sum && sub && !mult && !div)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Fase_1_Subtracao");
        }
        else if(sum && sub && !mult && !div)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Fase_1_So_Sub");
        }
        else //PopUp de funcionalidade nao implementada
        {
            notImplemented.SetActive(true);
        }
    }



    public void changeSound()
    {
      

        GameManagerControllerMenu.somActive = !GameManagerControllerMenu.somActive;

        if (GameManagerControllerMenu.somActive)
        {
            soundOption.text = "Ligado";
        }
        else
        {
            soundOption.text = "Desligado";
        }


        if (music.isPlaying && !somActive)
        {
            music.Pause();
        }
        else if (!music.isPlaying && somActive)
        {
            music.Play();
        }

    }

    public void enableOperation(int op)
    {

        GameManagerControllerMenu.operations[op] = !GameManagerControllerMenu.operations[op];

        if (GameManagerControllerMenu.operations[op])
        {
            stateOptions[op].text = "Ligado";
        }
        else
        {
            stateOptions[op].text = "Desligado";
        }

    }

   




    public void goToConfiguracoes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Config");
    }


    public void voltarMenuInicial()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_Inicial");


    }


    public void exitGame()
    {
        Application.Quit();
    }
}
