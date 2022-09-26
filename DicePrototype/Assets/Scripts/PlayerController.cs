using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //
    private TableController tableController;
    private int currentSquare = 0;
    private int objectiveSquare = 0;
    //private bool moving = false;
    private int currentLap = 0;
    private int objectiveLap = 0;

    // Start is called before the first frame update
    void Start()
    {
        tableController = FindObjectOfType<TableController>();
        //
        transform.position = tableController.squareControllers[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int amount)
    {
        //transform.position = tableController.squareControllers[amount - 1].transform.position;
        objectiveSquare = currentSquare + amount;
        if(objectiveSquare >= tableController.squareControllers.Length)
        {
            objectiveSquare = objectiveSquare - tableController.squareControllers.Length;
            objectiveLap++;
        }
        //moving = true;
        StartCoroutine(NormalMovement());
    }

    IEnumerator NormalMovement()
    {
        int stepsToDo = 20;
        SquareController nextSquare = (currentSquare < tableController.squareControllers.Length - 1) ?
                                         tableController.squareControllers[currentSquare + 1] :
                                         tableController.squareControllers[0];
        //
        for (int i = 0; i < stepsToDo; i++)
        {
            yield return new WaitForSeconds(0.02f);
            Vector3 nextPosition = Vector3.Lerp(
                tableController.squareControllers[currentSquare].transform.position, 
                nextSquare.transform.position,
                (float)i / (float)stepsToDo);
            nextPosition.y = Mathf.Sin((float)i / (float)stepsToDo * Mathf.PI);
            transform.position = nextPosition;
        }
        //
        if(currentSquare < tableController.squareControllers.Length-1)
            currentSquare++;
        else
        {
            currentSquare = 0;
            currentLap++;
        }
        //
        if(currentSquare < objectiveSquare || currentLap < objectiveLap)
        {
            StartCoroutine(NormalMovement());        
        }
    }
}
