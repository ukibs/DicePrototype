using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    //
    public GameObject dicePrefab;
    public int diceToSpawn = 6;

    //
    private List<GameObject> activeDice;

    // Start is called before the first frame update
    void Start()
    {
        activeDice = new List<GameObject>(diceToSpawn);
        SpawnDice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDice()
    {
        //
        float distanceBetweenDice = 2;
        //
        for(int i = 0; i < diceToSpawn; i++)
        {
            Vector3 newPosition = new Vector3(i * distanceBetweenDice - (diceToSpawn * distanceBetweenDice / 2), 10, 0);
            GameObject newDice = Instantiate(dicePrefab, newPosition, Quaternion.identity);
            activeDice.Add(newDice);
            //
            Rigidbody rb = newDice.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(2, -1, 2) * 10, ForceMode.Impulse);
        }
    }

    public void ClearDice()
    {
        for (int i = 0; i < activeDice.Count; i++)
        {
            Destroy(activeDice[i]);
        }
        activeDice.Clear();
    }
}
