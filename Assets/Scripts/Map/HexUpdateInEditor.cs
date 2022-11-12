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
    public HexCell cell;
    public MeshFilter cellMeshFilter;

    void Start()
    {
        cell = GetComponent<HexCell>();
        cellMeshFilter = GetComponent<MeshFilter>(); ;
    }

    void Update()
    {
        if (this.transform.parent != null && inventory != null)
        {//move the cell when hexCoord is updated
            map = this.transform.parent.gameObject;//if wirtethis in Awake(), got an error...So it comes here
            float delX = inventory.hexEdgeLength * cell.hexCoord.x * Mathf.Sqrt(3) - inventory.hexEdgeLength * cell.hexCoord.y * Mathf.Sqrt(3) / 2;
            float delZ = inventory.hexEdgeLength * cell.hexCoord.y * 3 / 2;
            Vector3 delTrans = new Vector3(delX, 0.0F, delZ);
            this.transform.position = map.transform.position + delTrans;
            cell.UpdateCell();
        }
    }
}