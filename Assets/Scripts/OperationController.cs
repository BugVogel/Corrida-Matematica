using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationController : MonoBehaviour
{


    [SerializeField]
    private GameObject resultTileSubtration;

    [SerializeField]
    private float resultado;


    [SerializeField]
    private float[][] locations;


    private LinkedList<GameObject> tiles;



    [SerializeField]
    private int operation;


    private float currentResult = 0;


    [SerializeField]
    private GameObject numResul;


    [SerializeField]
    private GameObject tileBefore;

    [SerializeField]
    private GameObject tileAfter;

    LinkedList<GameObject> tilesBeforeAfter = new LinkedList<GameObject>();

    private GameManagerControllerFase gameManagerController;

    [SerializeField]
    private GameObject wrongSignal;

    private Vector3 tileRef;

    private float timer = 0;

    [SerializeField]
    private bool opConcluded = false;

    [SerializeField]
    private int operandosSub;

    [SerializeField]
    private GameObject[] destroyTile;

    



    void Start()
    {

        if (operation > 2) //Para ocorrer a multiplicação sem zerar
            currentResult = 1;

        tiles = new LinkedList<GameObject>();


        tilesBeforeAfter.AddFirst(tileAfter);
        tilesBeforeAfter.AddFirst(tileBefore);

        gameManagerController = GameObject.Find("GameManager").GetComponent<GameManagerControllerFase>();
    }

   
    void Update()
    {



        timer += Time.deltaTime;
       
    }

    public void setOperation(int operation)
    {
        this.operation = operation;
    }

    public void setResultado(int resultado)
    {
        this.resultado = resultado;
    }






    public void doOperation( int value, GameObject tile)
    {

       

        if (!tiles.Contains(tile) && !opConcluded) //Só faz operação para bloco que não clicou ainda e se nao tiver achado o resultado ainda
        {

            tile.GetComponent<TilesController>().paintBlue();

            tiles.AddLast(tile);

            switch (operation)
            {

                case 0: //Soma
                    currentResult += value;

                    currentResult = Mathf.Abs(currentResult);

                    if (currentResult == resultado) //acertou
                    {
                       
                        sumWithTiles();
                        gameManagerController.addOpCorreta();
                        currentResult = 0;

                        

                    }
                    else if(currentResult > resultado)//Errou
                    {
                       
                        currentResult = 0;
                        foreach(GameObject t in tiles)
                        {
                            StartCoroutine(t.GetComponent<TilesController>().removeBlue(0));
                        }
                       
                        showWrong();
                    }
                    break;

                case 1: //Subtração


                    if (currentResult == 0)
                    {//Agrega para subtração
                        currentResult += value;
                        timer = 0; //₢ooldown
                    }
                    else
                    {
                        if(currentResult >= value)
                        {
                            currentResult -= value;
                        }
                        else
                        {
                            currentResult = value - currentResult;
                        }

                       
                        
                    }

                    //currentResult = Mathf.Abs(currentResult);
                    if (tiles.Count >= operandosSub) //Usou o número de operandos necessários
                    {
                       
                        if (resultado == currentResult) //Acertou
                        {
                          
                            subtractionWithTiles();
                            gameManagerController.addOpCorreta();
                            currentResult = 0;
                        }
                        else  //Errou a conta
                        {
                            
                            currentResult = 0;
                            foreach (GameObject t in tiles)
                            {
                                StartCoroutine(t.GetComponent<TilesController>().removeBlue(0));
                            }
                            showWrong();
                        }
                    }
                    



                    break;

                case 3: //Divisão

                    if (currentResult == 0) //Agrega para divisão
                        currentResult += value;
                    else
                        currentResult /= value;

                    currentResult = Mathf.Abs(currentResult);


                    break;

                case 2://Multiplicação

                    currentResult *= value;

                    currentResult = Mathf.Abs(currentResult);

                    break;

                default:
                    Debug.Log("Tile sem operação definida");
                    break;

            }
                

        }

      




    }



   



    public void showWrong()
    {

        

        while (tiles.First != null)
        {
           
            LinkedListNode<GameObject> tileNode = tiles.First;

            GameObject tile = tileNode.Value;

            Vector3 target = tile.transform.position;
            target.z = -9.53f;

            GameObject wrong = Instantiate(wrongSignal, target, Quaternion.identity);
            Destroy(wrong, 0.5f);
            




            tiles.RemoveFirst();
        }

       

    }

    private void subtractionWithTiles()
    {


        for(int i=0; i<destroyTile.Length;i++)
        {

            

            GameObject tileObj = destroyTile[i];

            Destroy(tileObj);

            
        }


            opConcluded = true;

            while (tiles.First != null)
            {

                LinkedListNode<GameObject> tileNode = tiles.First;

                GameObject tileObj = tileNode.Value;

                BoxCollider2D boxTile = tileObj.GetComponent<BoxCollider2D>();

                boxTile.isTrigger = false;

                Destroy(tileObj);

                tiles.RemoveFirst();
            }


            if (resultTileSubtration != null)
            {
                BoxCollider2D boxRef = tilesBeforeAfter.First.Value.GetComponent<BoxCollider2D>();
                BoxCollider2D boxTileResult = resultTileSubtration.GetComponent<BoxCollider2D>();

                GameObject block1 = tilesBeforeAfter.First.Value; //Deve ser colocado um block1 embaixo do lugar que a parede estar para o resultado ir

                Vector3 tileRef = new Vector3(block1.transform.position.x, block1.transform.position.y+ (1.63f*resultado), -0.73f);
           
                if(numResul != null)
                Destroy(numResul);



                float positionx = tileRef.x;
                float positiony = tileRef.y-0.4f;

                TilesController resultController = resultTileSubtration.GetComponent<TilesController>();
                resultController.setLocationX(positionx);
                resultController.setLocaltionY(positiony);
                resultController.isNotBlocking();
                resultController.move();
            }


    }


    private void sumWithTiles()
    {

        opConcluded = true;
        

        Vector3 tileRef = new Vector3(tilesBeforeAfter.First.Value.GetComponent<BoxCollider2D>().bounds.max.x, tilesBeforeAfter.First.Value.GetComponent<BoxCollider2D>().bounds.max.y, -0.73f);

        Destroy(numResul);

        while (tiles.First != null)
        {

            LinkedListNode<GameObject> tileNode = tiles.First;

            GameObject tileObj = tileNode.Value;

            BoxCollider2D boxTile = tileObj.GetComponent<BoxCollider2D>();

            boxTile.isTrigger = false;




            TilesController tileController = tileObj.GetComponent<TilesController>();
        
            float positionx = tileRef.x + boxTile.bounds.extents.x;
            float positiony = tileRef.y - boxTile.bounds.extents.y;

            


            tileController.setLocationX(positionx-defasagem(tileObj.tag));
            tileController.setLocaltionY(positiony);

            tileController.move();

            tileRef = new Vector3(positionx + boxTile.bounds.extents.x, positiony + boxTile.bounds.extents.y, -0.73f);
            tiles.RemoveFirst();


        }

        
    }


    private float defasagem(string tag) //Calcula defasagem que estava tendo
    {
       


        switch (tag)
        {


            case "Dois":
                return 0.79f;
                

            case "Tres":
                return 1.6f;
                

            case "Quatro":
                return 2.4f;
               





        }


        return 0;
    }


}
