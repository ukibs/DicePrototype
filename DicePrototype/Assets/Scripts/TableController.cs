using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    //
    [HideInInspector] public SquareController[] squareControllers;

    // Start is called before the first frame update
    void Start()
    {
        squareControllers = GetComponentsInChildren<SquareController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
