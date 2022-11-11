using cakeslice;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class HexCell : MonoBehaviour
{

    #region variables
    [Tooltip("该格子的六边形坐标")]
    public Vector2Int hexCoord;
    [Tooltip("该单元格高度")]
    public int altitude;
    [Tooltip("是否被临时高亮")]
    public bool highLighted;
    [Tooltip("正面或者反面")]//dont use this temporarily
    public bool isOnTheFrontSide;
    [Tooltip("格子所带的元素，可以为NONE")]
    public Inventory.Element cellElement;
    [Tooltip("决定这个格是不是神秘格子或者要塞或者别的什么特殊效果，可以为NONE")]
    public Inventory.SpecialCellType specialCellType;
    [Tooltip("格子的所有sprite素材，特效，粒子系统预制体等都在这个类里")]
    public GridInventory inventory;
    [Tooltip("这是该物体的Outline Shader，以用于高亮，注意需要实例化一个之后再更改，不然的话所有的shader都会被改（已封装，不用管）")]
    public Material thisOutlineMaterial;

    #endregion

    #region methods for Map to use
    /// <summary>
    /// 根据全局变量thisGrid来更新当前地图单元
    /// </summary>
    public void UpdateCell()
    {
        /*如果存在元素，这个单元格会被施加特效
         *单元格对应的模型材质等资源引用，由高度和附近的单元格共同决定（比如高度相同的两座山连着形成山脉）
         *这些也需要更新，我还没写
         *但是这里不包含高亮状态的更新
         */
        //更新cellMesh
        MeshFilter cellMesh = GetComponent<MeshFilter>();
        cellMesh.sharedMesh = altitude switch
        {
            3 => inventory.mountain3.mesh,
            2 => inventory.hill2.mesh,
            1 => inventory.hill1.mesh,
            0 => inventory.ground0.mesh,
            -1 => inventory.pit_1.mesh,
            -2 => inventory.basin_2.mesh,
            -3 => inventory.valley_3.mesh,
            _ => inventory.hole.mesh,
        };
        //update material
        MeshRenderer cellRenderer = GetComponent<MeshRenderer>();
        cellRenderer.sharedMaterial = altitude switch
        {
            3 => inventory.mountain3.material,
            2 => inventory.hill2.material,
            1 => inventory.hill1.material,
            0 => inventory.ground0.material,
            -1 => inventory.pit_1.material,
            -2 => inventory.basin_2.material,
            -3 => inventory.valley_3.material,
            _ => inventory.hole.material,
        };
        //更新meshCollider
        GetComponent<MeshCollider>().sharedMesh = cellMesh.sharedMesh;
        //add special effect
        //add partical system
    }
    /// <summary>
    /// 将这一块地图格子高亮
    /// </summary>
    /// <param name="highLightMode">高亮模式，可以为NONE</param>
    public void HighlightCell(Inventory.HighlightMode highLightMode)
    {
        Outline outline = GetComponent<Outline>();
        switch (highLightMode)
        {
            case Inventory.HighlightMode.mouseTarget:
                break;
            case Inventory.HighlightMode.attackTarget:
                break;
            case Inventory.HighlightMode.attackRange:
                break;
            case Inventory.HighlightMode.moveRange:
                break;
            case Inventory.HighlightMode.moveTarget:
                outline.enabled = true;
                outline.color = 0;
                break;
            case Inventory.HighlightMode.None:
                outline.enabled = false;
                break;
        }
    }
    /// <summary>
    /// 地图上的元素反应，输入某元素，改变Element，产生反应，并达到某效果
    /// </summary>
    /// <param name="elementIn">传入的元素</param>
    public void ElementReactionOnMap(Inventory.Element elementIn)
    {

    }
    /// <summary>
    /// 小兵站在该格子上时，每回合执行一次
    /// </summary>
    /// <param name="chess">站在上面的棋子</param>
    public void OnChessStand(GameObject chess)
    {

    }
    /// <summary>
    /// 小兵与该格子交互时执行一次
    /// </summary>
    /// <param name="chess">与之交互的棋子</param>
    public void OnChessInterface(GameObject chess)
    {

    }
    /// <summary>
    /// 鼠标点击该格子时执行，也许是显示信息？
    /// </summary>
    public void MapGridOnClick()
    {
        
    }
    #endregion

    #region methods for Self to use
    /// <summary>
    /// 这个方法用来将该物体初始化，初始化的函数都可以放在这里 
    /// </summary>
    void Initialize()
    {
        //cellMesh = GetComponent<MeshFilter>().mesh;
    }
    #endregion

    private void Start()
    {
        Initialize();
        UpdateCell();//脚本实例化时进行一次更新
    }
    private void Update()
    {
        UpdateCell();
    }
}
