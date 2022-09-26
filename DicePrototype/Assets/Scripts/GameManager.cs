using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //
    [HideInInspector] public int currentPlayerIndex = 0;
    //
    private DiceManager diceManager;
    private PlayerController[] playerControllers;

    // Start is called before the first frame update
    void Start()
    {
        diceManager = FindObjectOfType<DiceManager>();
        playerControllers = FindObjectsOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(int amount)
    {
        playerControllers[currentPlayerIndex].Move(amount);
        //
        currentPlayerIndex++;
        if (currentPlayerIndex >= playerControllers.Length)
            currentPlayerIndex = 0;
        //
        diceManager.ClearDice();
        //
        diceManager.SpawnDice();
    }
}
