using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    #region ����

    [Tooltip("��ͼ��ά��������߽�")]
    private const int maxRaw = 100, maxLine = 100;

    #endregion

    #region ����

    [Tooltip("��Grid��uv����Ϊ�����Ķ�ά���飬�����ͼ�ĸ���")]
    [SerializeField] public GameObject[,] MapGrids = new GameObject[maxRaw, maxLine];

    [Tooltip("GridLayoutGrounp���������")]
    public int gridLayoutGrounpMaxRaw;

    [Tooltip("GridLayoutGrounp���м�����м��")]
    public float gridLayoutGrounpRawGap, gridLayoutGrounpLineGap;
    #endregion

    #region Debug������releaseʱɾ��

    public Vector2Int ����������Ҫ�鿴������;
    public GameObject ��ά����鿴��;

    #endregion

    #region ����MapManager���õķ�����

    /// <summary>
    /// �����������������ת��ΪhexTilemap��cell���꣨ע��������VECTOR3INT�������أ�Ҫȷ��������������һ�����ӵ����꣬���������Ū��һ����ά������
    /// </summary>
    /// <param name="WorldPos">��������</param>
    /// <returns>ת�����cell����</returns>
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
    /// ���������hexTilemap��cell���꣨ע��������VECTOR3INT��ת��Ϊ�������겢����
    /// </summary>
    /// <param name="HexPos">cell����</param>
    /// <returns>ת�������������</returns>
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
    /// �ú�����Ŀ��ĵ�ͼ���ӵĸ���ģʽ�ı䣨���������������EnumDefinition.HighlightMode.None��
    /// </summary>
    /// <param name="target">һ�����������еĴ����ĸ��ӵ�List<MapGrid>����</param>
    /// <param name="highlightMode">����ģʽ������ΪNone</param>
    public void HighlightMapGrids(List<MapGrid> target, EnumDefinition.HighlightMode highlightMode)
    {
        foreach(MapGrid grid in target)
        {
            grid.HighlightGrid(highlightMode);
        }
    }

    /// <summary>
    /// �ú����ı�һ�����ӵĸ߶�
    /// </summary>
    /// <param name="target">Ŀ����ӵ�list</param>
    /// <param name="delta">�仯��</param>
    public void ChangeMapGridsAltitude(List<MapGrid> target, int delta)
    {
        foreach (MapGrid grid in target)
        {
            grid.thisGrid.altitude += delta;
        }
    }

    /// <summary>
    /// ��һ�������ϲ���Ԫ�ط�Ӧ
    /// </summary>
    /// <param name="target">Ŀ�����list</param>
    /// <param name="elementIn">�����Ԫ��</param>
    public void ElementalReaction(List<MapGrid> target, EnumDefinition.Element elementIn)
    {
        foreach (MapGrid grid in target)
        {
            grid.ElementReactionOnMap(elementIn);
        }
    }

    /// <summary>
    /// ������վ�ڸ�����ʱ��ÿ�غϵ���һ��
    /// </summary>
    /// <param name="gridHexPos">���ӵ�cell����</param>
    /// <param name="chess">����</param>
    public void OnStand(Vector3Int gridHexPos, GameObject chess)
    {
        MapGrids[gridHexPos.x, gridHexPos.y].GetComponent<MapGrid>().OnChessStand(chess);
    }

    /// <summary>
    /// ����������ӽ���ʱ����
    /// </summary>
    /// <param name="gridHexPos">���ӵ�cell����</param>
    /// <param name="chess">����</param>
    public void OnInterface(Vector3Int gridHexPos, GameObject chess)
    {
        MapGrids[gridHexPos.x, gridHexPos.y].GetComponent<MapGrid>().OnChessInterface(chess);
    }

    /// <summary>
    /// ���ĳ����ͼ����ʱ����
    /// </summary>
    /// <param name="hexPos">��ͼ���ӵ�cell����</param>
    public void Click(Vector3Int hexPos)
    {
        MapGrids[hexPos.x, hexPos.y].GetComponent<MapGrid>().MapGridOnClick();
    }

    /// <summary>
    /// �ú�����ָ��λ��������һ����ͼ����
    /// </summary>
    /// <param name="targetPos">Ŀ��λ��</param>
    /// <param name="gridPrefab">�������ɵ�gameobjectԤ����</param>
    /// <param name="targetBase">����Ŀ����ӵ��������Ե�MapGrid����</param>
    /// <param name="isOnTheFrontSide">�Ƿ�λ�������ͼ</param>
    public void InstantiateGrid(Vector3Int targetPos, MapGridBase targetBase)
    {
        GameObject temp = MapGrids[targetPos.x, targetPos.y];
        temp.SetActive(true);
        temp.GetComponent<MapGrid>().thisGrid = targetBase;
        temp.GetComponent<MapGrid>().UpdateGrid();
    }

    /// <summary>
    /// �ú�������ָ��λ���ϵĸ���
    /// </summary>
    /// <param name="targetPos">Ŀ��λ��</param>
    /// <param name="isOnTheFrontSide">�Ƿ�λ�������ͼ</param>
    public void DestroyGrid(Vector3Int targetPos)
    {
        GameObject temp = MapGrids[targetPos.x, targetPos.y];
        temp.SetActive(false);
    }

    #endregion

    #region ������Ҫ���õķ�����
    /// <summary>
    /// �ú���������������Ϊ��㣬��������UnityGridLayoutGrounp�ķ�ʽ������������������г�����������״�����ҽ���Ӧ���Ӵ���MapGrids��ά����
    /// </summary>
    /// <param name="maxRaw">����������༴����������˾ͻ���</param>
    /// <param name="rawGap">�м��</param>
    /// <param name="lineGap">�м��</param>
    void GridPermutation(int maxRaw, float rawGap, float lineGap)
    {
        int rawIndex = 0, lineIndex = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            lineIndex = i / maxRaw;
            rawIndex = i % maxRaw;
            transform.GetChild(i).transform.position = transform.position + new Vector3(rawIndex * rawGap, lineIndex * lineGap, 0) + ((lineIndex % 2 == 1) ? new Vector3(rawGap / 2, 0, 0) : Vector3.zero);
            MapGrids[rawIndex, lineIndex] = transform.GetChild(i).gameObject;
        }
    }

    #endregion

    #region Debug�����飬releaseʱɾ��

    void Debug()
    {
        ��ά����鿴�� = MapGrids[����������Ҫ�鿴������.x, ����������Ҫ�鿴������.y];
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