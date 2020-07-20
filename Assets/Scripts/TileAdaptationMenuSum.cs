using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAdaptationMenuSum : MonoBehaviour
{
    
    [SerializeField]
    private float positionx;

    [SerializeField]
    private float positiony;

    [SerializeField]
    private bool move;

    private float velocity = 8f;

    [SerializeField]
    private GameObject numResult;

    void Start()
    {
        if(numResult != null)
        Destroy(numResult, 0.4f);
        
    }

    
    void Update()
    {

        if (move)
        {

            float mul = velocity * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(positionx, positiony, transform.position.z), mul);
        }

    }
}
