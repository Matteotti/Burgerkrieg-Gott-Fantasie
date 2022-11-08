using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexCoordInEditor : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField]private GameObject map;//the parent map(front or back)
    public HexCell cell;
    
    void Start(){
        cell = GetComponent<HexCell>();
    }

    void Update(){
        if(this.transform.parent != null && inventory != null) {//move the cell when hexCoord is updated
            map = this.transform.parent.gameObject;//if wirtethis in Awake(), got an error...So it comes here
            float delX = inventory.hexEdgeLength * cell.hexCoord.x * Mathf.Sqrt(3) - inventory.hexEdgeLength * cell.hexCoord.y * Mathf.Sqrt(3)/2;
            float delZ = inventory.hexEdgeLength * cell.hexCoord.y * 3/2;
            Vector3 delTrans = new Vector3(delX, 0.0F, delZ);
            this.transform.position = map.transform.position + delTrans;
        }       
    }
}
