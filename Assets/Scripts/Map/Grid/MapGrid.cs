using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{

    #region variables
    [Tooltip("这是该脚本引用的持久化资源，不可被更改，在这里放入GridBase")]
    public MapGridBase baseGrid;
    [Tooltip("这是该脚本自己的MapUnit属性，应该更改的是这个")]
    public MapGridBase thisGrid;
    [Tooltip("格子的所有sprite素材，特效，粒子系统预制体等都在这个类里")]
    public GridInventory inventory;
    [Tooltip("这是该物体的Outline Shader，以用于高亮，注意需要实例化一个之后再更改，不然的话所有的shader都会被改（已封装，不用管）")]
    public Material thisOutlineMaterial;
    #endregion

    #region methods for Map to use
    /// <summary>
    /// 根据全局变量thisGrid来更新当前地图单元
    /// </summary>
    public void UpdateGrid()
    {
        /*如果存在元素，这个单元格会被施加特效
         *单元格对应的模型材质等资源引用，由高度和附近的单元格共同决定（比如高度相同的两座山连着形成山脉）
         *这些也需要更新，我还没写
         *但是这里不包含高亮状态的更新
         */
        switch (thisGrid.altitude)
        {
            case -3:
                thisGrid.gridSprite = inventory.mountain3;
                break;
            case -2:
                thisGrid.gridSprite = inventory.hill2;
                break;
            case -1:
                thisGrid.gridSprite = inventory.hill1;
                break;
            case 0:
                thisGrid.gridSprite = inventory.ground0;
                break;
            case 1:
                thisGrid.gridSprite = inventory.basin_1;
                break;
            case 2:
                thisGrid.gridSprite = inventory.valley_2;
                break;
            case 3:
                thisGrid.gridSprite = inventory.pit_3;
                break;
            default:
                thisGrid.gridSprite = inventory.hole;
                break;
        }//不同的高度对应不同的贴图，之后更新贴图
        GetComponent<SpriteRenderer>().sprite = thisGrid.gridSprite;
    }
    /// <summary>
    /// 将这一块地图格子高亮
    /// </summary>
    /// <param name="highLightMode">高亮模式，可以为NONE</param>
    public void HighlightGrid(EnumDefinition.HighlightMode highLightMode)
    {
        switch (highLightMode)
        {
            case EnumDefinition.HighlightMode.mouseTarget:
                thisOutlineMaterial.SetColor("lineColor", Color.grey);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.attackTarget:
                thisOutlineMaterial.SetColor("lineColor", Color.red);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.attackRange:
                thisOutlineMaterial.SetColor("lineColor", Color.green);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.moveRange:
                thisOutlineMaterial.SetColor("lineColor", Color.blue);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.moveTarget:
                thisOutlineMaterial.SetColor("lineColor", Color.black);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.None:
                thisOutlineMaterial.SetFloat("lineWidth", 0);
                break;
        }
    }
    /// <summary>
    /// 地图上的元素反应，输入某元素，改变Element，产生反应，并达到某效果
    /// </summary>
    /// <param name="elementIn">传入的元素</param>
    public void ElementReactionOnMap(EnumDefinition.Element elementIn)
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
    /// 这个方法用来生成一个单独的material，用来单独更改某一个gameobject的material而不至于全部更改  
    /// </summary>
    void MaterialInitialize()
    {
        thisOutlineMaterial = Instantiate(thisOutlineMaterial);
        GetComponent<SpriteRenderer>().material = thisOutlineMaterial;
    }
    #endregion

    private void Start()
    {
        thisGrid = Instantiate(baseGrid);
        MaterialInitialize();
        UpdateGrid();//脚本实例化时进行一次更新
    }
}
