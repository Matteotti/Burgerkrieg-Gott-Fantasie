using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class Maps : MonoBehaviour
{
    public GridInventory gridInventory;
    [Tooltip("HexMap for frontMap")]
    public GameObject front;
    [Tooltip("HexMap for backMap")]
    public GameObject back;

    void Start(){
        gridInventory.frontMap = new GameObject[100,100];
        gridInventory.backMap = new GameObject[100,100];
    }
}