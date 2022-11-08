using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexCoordInEditor : MonoBehaviour
{
    [SerializeField]private float edgeLength;//size of each cell, measured as the length of each edge
    private GameObject map;//the parent map(front or back)
    public HexCell cell;
    
    void Start(){
        edgeLength = 1.0f;
        cell = GetComponent<HexCell>();
        map = this.transform.parent.gameObject;//if wirtethis in Awake(), got an error...So it comes here
    }

    void Update(){
        //move the cell when hexCoord is updated
        float delX = edgeLength * cell.hexCoord.x * Mathf.Sqrt(3) - edgeLength * cell.hexCoord.y * Mathf.Sqrt(3)/2;
        float delZ = edgeLength * cell.hexCoord.y * 3/2;
        Vector3 delTrans = new Vector3(delX, 0.0F, delZ);
        this.transform.position = map.transform.position + delTrans;
    }
}
