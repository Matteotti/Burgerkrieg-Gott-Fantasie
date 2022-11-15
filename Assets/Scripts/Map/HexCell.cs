using cakeslice;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public GridInventory gridInventory;
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
            3 => gridInventory.mountain3.mesh,
            2 => gridInventory.hill2.mesh,
            1 => gridInventory.hill1.mesh,
            0 => gridInventory.ground0.mesh,
            -1 => gridInventory.pit_1.mesh,
            -2 => gridInventory.basin_2.mesh,
            -3 => gridInventory.valley_3.mesh,
            _ => gridInventory.hole.mesh,
        };
        //update material
        MeshRenderer cellRenderer = GetComponent<MeshRenderer>();
        cellRenderer.sharedMaterial = altitude switch
        {
            3 => gridInventory.mountain3.material,
            2 => gridInventory.hill2.material,
            1 => gridInventory.hill1.material,
            0 => gridInventory.ground0.material,
            -1 => gridInventory.pit_1.material,
            -2 => gridInventory.basin_2.material,
            -3 => gridInventory.valley_3.material,
            _ => gridInventory.hole.material,
        };
        //更新meshCollider
        GetComponent<MeshCollider>().sharedMesh = cellMesh.sharedMesh;
        //add special effect

        //add partical system
        //check element
        GameObject cellElementEffect = cellElement switch
        {
            Inventory.Element.red => gridInventory.elementEffects.red,
            Inventory.Element.blue => gridInventory.elementEffects.blue,
            Inventory.Element.green => gridInventory.elementEffects.green,
            Inventory.Element.yellow => gridInventory.elementEffects.yellow,
            _ => null
        };
        //Debug.Log(cellElementEffect);
        //delete previous effects
        for(int i = 0; i<gameObject.transform.childCount; i++){
                GameObject.DestroyImmediate(gameObject.transform.GetChild(i).gameObject);   
        }
        //add new effects if should
        if (cellElementEffect != null){
            GameObject effectInstance = GameObject.Instantiate(cellElementEffect,transform.position,transform.rotation);
            effectInstance.transform.SetParent(gameObject.transform);
        }
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
                outline.enabled = true;
                outline.color = 0;
                break;
            case Inventory.HighlightMode.attackTarget:
                break;
            case Inventory.HighlightMode.attackRange:
                break;
            case Inventory.HighlightMode.moveRange:
                break;
            case Inventory.HighlightMode.moveTarget:
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
    /// 鼠标点击该格子时执行，要做什么由传入的enum决定,第二个可选参数为要把格子的某个属性更改为的目标数字，如高度，enum的index等等，默认为0
    /// </summary>
    /// <param name="clickMode">点击需要格子做些什么？</param>
    /// <param name="targetNum">可选的传入整数，标志着目标值什么什么的</param>
    /// <returns>返回这个格子的实例类：hexCell</returns>
    public HexCell MapGridOnClick(Inventory.HexCellClickMode clickMode, [DefaultValue(0)] int targetNum)
    {
        switch(clickMode)
        {
            case Inventory.HexCellClickMode.Altitude:
                altitude = targetNum;
                break;
            case Inventory.HexCellClickMode.Element:
                cellElement = (Inventory.Element)targetNum;
                break;
            case Inventory.HexCellClickMode.Target:
                //仅仅是把格子作为目标，什么也不做
                break;
            case Inventory.HexCellClickMode.Info:
                ShowCellInfo();
                //显示格子信息，我做个UI
                break;
        }
        return this;
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
    void ShowCellInfo()
    {
        Debug.Log("ShowInfo Height Element Cood");
        //显示格子信息，我做个UI
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
