using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
//将脚本添加至地图格子上，使其在编辑器中可以实时更新，更新的包括位置和mesh等
public class HexUpdateInEditor : MonoBehaviour
{
    public Inventory inventory;
    public GridInventory gridInventory;
    [SerializeField] private GameObject map;//the parent map(front or back)
    HexCell cell;
    MeshFilter cellMeshFilter;
    public bool shouldUpdate = false;
    void Start()
    {
        cell = GetComponent<HexCell>();
        cellMeshFilter = GetComponent<MeshFilter>(); 
    }

    void Update()
    {
        if (shouldUpdate && this.transform.parent != null && inventory != null)
        {   //move the cell when hexCoord is updated
            Vector3 localOrigin = this.transform.parent.gameObject.transform.position;//world position of father
            float delX = inventory.hexEdgeLength * cell.hexCoord.x * Mathf.Sqrt(3) - inventory.hexEdgeLength * cell.hexCoord.y * Mathf.Sqrt(3) / 2;
            float delZ = inventory.hexEdgeLength * cell.hexCoord.y * 3 / 2;
            Vector3 delTrans = new Vector3(delX, 0.0F, delZ);
            this.transform.position = localOrigin + delTrans;
            //set rotation
            this.transform.eulerAngles = new Vector3(0,0,0);
            //set the scale to fit the mesh scale
            this.transform.localScale = new Vector3(inventory.hexScale, inventory.hexScale, inventory.hexScale);
            //update the cell
            cell.UpdateCell();

            ///更新gridInventory里的索引(GameObject是引用类型，可以直接赋值)//怎么清理之前的索引...？
               
            if(cell.isOnTheFrontSide){ //Debug.Log(gridInventory.frontMap[cell.hexCoord.x,cell.hexCoord.y]);
                gridInventory.frontMap[cell.hexCoord.x,cell.hexCoord.y] = gameObject;
            }else{
                gridInventory.backMap[cell.hexCoord.x,cell.hexCoord.y] = gameObject;
                //Debug.Log(gridInventory.map[cell.hexCoord.x,cell.hexCoord.y].frontCell);
            }
           
        }
    }
}