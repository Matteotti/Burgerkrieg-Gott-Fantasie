using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] cells;
    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("Cell");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMoveRange() 
    { 
    
    }
    public void ShowAttackRange()
    {

    }

    public void CloseMoveRange()
    {

    }
    public void GetDamage()
    {

    }
}
