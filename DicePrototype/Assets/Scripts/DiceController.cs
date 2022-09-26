using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{

    private bool velocityCanBeChecked = false;
    private Rigidbody rb;
    private GameManager gameManager;

    private int result = -1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        SetRandonRotation();
        StartCoroutine(WaitAndAllowVelocityCheck());
    }

    // Update is called once per frame
    void Update()
    {
        if (velocityCanBeChecked)
        {
            if(rb.velocity.sqrMagnitude == 0)
            {
                velocityCanBeChecked = false;
                //Debug.Log(transform.forward);
                CheckUpperSide();
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Click on dice");
        if(result != -1)
            gameManager.MovePlayer(result);
    }

    void SetRandonRotation()
    {
        transform.eulerAngles = new Vector3(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360));
    }

    IEnumerator WaitAndAllowVelocityCheck()
    {
        yield return new WaitForSeconds(0.2f);
        velocityCanBeChecked = true;
    }

    void CheckUpperSide()
    {
        // Layer para los loados de dado
        int layerMask = 1 << 6;
        RaycastHit hitInfo;
        //
        if(Physics.Raycast(transform.position + (Vector3.up * 10), Vector3.down, out hitInfo, layerMask))
        {
            SideData sideData = hitInfo.collider.GetComponent<SideData>();
            if (sideData)
            {
                Debug.Log(sideData.value);
                result = sideData.value;
            }
            else
            {
                Debug.Log("Error getting dice value");
                Debug.Log(hitInfo.collider.name);
            }
        }
    }
}
