using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    #region constants

    [Tooltip("地图二维数组的最大边界")]
    private const int maxRaw = 100, maxLine = 100;

    #endregion

    #region variables

    [Tooltip("以Grid的uv坐标为索引的二维数组，储存地图的格子")]
    [SerializeField] public GameObject[,] mapCells = new GameObject[maxRaw, maxLine];

    [Tooltip("GridLayoutGrounp的最大列数")]
    public int gridLayoutGrounpMaxRaw;

    [Tooltip("GridLayoutGrounp的行间距与列间距")]
    public float gridLayoutGrounpRawGap, gridLayoutGrounpLineGap;
    #endregion

    #region Debug variables. Please delete them before releasing

    public Vector2Int coordToInspect;
    public GameObject array2DInspector;

    #endregion

    #region methods for MapManager to use

    /// <summary>
    /// 这个函数将世界坐标转化为hexTilemap的cell坐标（注意类型是VECTOR3INT）并返回（要确保你的输入真的是一个格子的坐标，而不是随便弄的一个三维向量）
    /// </summary>
    /// <param name="WorldPos">世界坐标</param>
    /// <returns>转化后的cell坐标</returns>
    public Vector3Int WorldPosToHexPos(Vector3 WorldPos)
    {
        float deltaX = WorldPos.x - transform.position.x, deltaY = WorldPos.y - transform.position.y;
        Vector3Int result = Vector3Int.zero;
        result.y = (int)(deltaY / gridLayoutGrounpLineGap);
        deltaX -= (result.y % 2 == 1) ? (gridLayoutGrounpRawGap / 2): 0;
        result.x = (int)(deltaX / gridLayoutGrounpRawGap);
        return result;
    }

    /// <summary>
    /// 这个函数将hexTilemap的cell坐标（注意类型是VECTOR3INT）转化为世界坐标并返回
    /// </summary>
    /// <param name="HexPos">cell坐标</param>
    /// <returns>转化后的世界坐标</returns>
    public Vector3 HexPosToWorldPos(Vector3Int HexPos)
    {
        int cellX = HexPos.x, cellY = HexPos.y;
        Vector3 worldPos = Vector3.zero;
        worldPos.y = cellY * gridLayoutGrounpLineGap / 2;
        worldPos.x = cellX * gridLayoutGrounpRawGap;
        worldPos.x += (worldPos.y % 2 == 1) ? gridLayoutGrounpRawGap / 2 : 0;
        return worldPos;
    }

    /// <summary>
    /// 该函数将目标的地图格子的高亮模式改变（若无需高亮，传入EnumDefinition.HighlightMode.None）
    /// </summary>
    /// <param name="target">一个包含了所有的待更改格子的List<MapGrid>变量</param>
    /// <param name="highlightMode">高亮模式，可以为None</param>
    public void HighlightmapCells(List<MapGrid> target, EnumDefinition.HighlightMode highlightMode)
    {
        foreach(MapGrid grid in target)
        {
            grid.HighlightGrid(highlightMode);
        }
    }

    /// <summary>
    /// 该函数改变一批格子的高度
    /// </summary>
    /// <param name="target">目标格子的list</param>
    /// <param name="delta">变化量</param>
    public void ChangemapCellsAltitude(List<MapGrid> target, int delta)
    {
        foreach (MapGrid grid in target)
        {
            grid.thisGrid.altitude += delta;
        }
    }

    /// <summary>
    /// 在一批格子上产生元素反应
    /// </summary>
    /// <param name="target">目标格子list</param>
    /// <param name="elementIn">传入的元素</param>
    public void ElementalReaction(List<MapGrid> target, EnumDefinition.Element elementIn)
    {
        foreach (MapGrid grid in target)
        {
            grid.ElementReactionOnMap(elementIn);
        }
    }

    /// <summary>
    /// 当棋子站在格子上时，每回合调用一次
    /// </summary>
    /// <param name="gridHexPos">格子的cell坐标</param>
    /// <param name="chess">棋子</param>
    public void OnStand(Vector3Int gridHexPos, GameObject chess)
    {
        mapCells[gridHexPos.x, gridHexPos.y].GetComponent<MapGrid>().OnChessStand(chess);
    }

    /// <summary>
    /// 当棋子与格子交互时调用
    /// </summary>
    /// <param name="gridHexPos">格子的cell坐标</param>
    /// <param name="chess">棋子</param>
    public void OnInterface(Vector3Int gridHexPos, GameObject chess)
    {
        mapCells[gridHexPos.x, gridHexPos.y].GetComponent<MapGrid>().OnChessInterface(chess);
    }

    /// <summary>
    /// 点击某个地图格子时调用
    /// </summary>
    /// <param name="hexPos">地图格子的cell坐标</param>
    public void Click(Vector3Int hexPos)
    {
        mapCells[hexPos.x, hexPos.y].GetComponent<MapGrid>().MapGridOnClick();
    }

    /// <summary>
    /// 该函数在指定位置上生成一个地图格子
    /// </summary>
    /// <param name="targetPos">目标位置</param>
    /// <param name="gridPrefab">用于生成的gameobject预制体</param>
    /// <param name="targetBase">储存目标格子的所有属性的MapGrid基类</param>
    /// <param name="isOnTheFrontSide">是否位于正面地图</param>
    public void InstantiateGrid(Vector3Int targetPos, MapGridBase targetBase)
    {
        GameObject temp = mapCells[targetPos.x, targetPos.y];
        temp.SetActive(true);
        temp.GetComponent<MapGrid>().thisGrid = targetBase;
        temp.GetComponent<MapGrid>().UpdateGrid();
    }

    /// <summary>
    /// 该函数销毁指定位置上的格子
    /// </summary>
    /// <param name="targetPos">目标位置</param>
    /// <param name="isOnTheFrontSide">是否位于正面地图</param>
    public void DestroyGrid(Vector3Int targetPos)
    {
        GameObject temp = mapCells[targetPos.x, targetPos.y];
        temp.SetActive(false);
    }

    #endregion

    #region methods for Self to use
    /// <summary>
    /// 该函数将以自身坐标为起点，以类似于UnityGridLayoutGrounp的方式对其子物体进行重排列成六边形网格状，并且将相应格子存入mapCells二维数组
    /// </summary>
    /// <param name="maxRaw">最大列数，亦即到这个列数了就换行</param>
    /// <param name="rawGap">行间距</param>
    /// <param name="lineGap">列间距</param>
    void GridPermutation(int maxRaw, float rawGap, float lineGap)
    {
        int rawIndex = 0, lineIndex = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            lineIndex = i / maxRaw;
            rawIndex = i % maxRaw;
            transform.GetChild(i).transform.position = transform.position + new Vector3(rawIndex * rawGap, lineIndex * lineGap, 0) + ((lineIndex % 2 == 1) ? new Vector3(rawGap / 2, 0, 0) : Vector3.zero);
            mapCells[rawIndex, lineIndex] = transform.GetChild(i).gameObject;
        }
    }

    #endregion

    #region Debug methods, Please delete them before releasing

    void Debug()
    {
        array2DInspector = mapCells[coordToInspect.x, coordToInspect.y];
    }

    #endregion
    private void Start()
    {
        GridPermutation(gridLayoutGrounpMaxRaw, gridLayoutGrounpRawGap, gridLayoutGrounpLineGap);
    }
    private void Update()
    {
        Debug();
    }
}