using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class HexCoord : MonoBehaviour
{
    private float edgeLength;//size of each cell, measured as the length of each edge
    private GameObject map;//the parent map(front or back)
    [Tooltip("；六边形斜坐标系。需要设置坐标时修改它")]
    public Vector2Int hexCoord;
    
    void Awake(){
        edgeLength = 10.0f;
        
    }

    void Update(){
        map = this.transform.parent.gameObject;//if wirtethis in Awake(), got an error...So it comes here
        //move the cell when hexCoord is updated
        float delX = edgeLength * hexCoord.x * Mathf.Sqrt(3) - edgeLength * hexCoord.y * Mathf.Sqrt(3)/2;
        float delZ = edgeLength * hexCoord.y * 3/2;
        Vector3 delTrans = new Vector3(delX, 0.0F, delZ);
        this.transform.position = map.transform.position + delTrans;
    }
}
