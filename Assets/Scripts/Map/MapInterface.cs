using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is an API...
public class MapInterface : MonoBehaviour
{
    public Inventory inventory;
    public GridInventory gridInventory;
    public StateInventory stateInventory;

    /// <summary>
    /// 这个函数将世界坐标转化为hexTilemap的cell坐标（注意类型是VECTOR3INT）并返回（要确保你的输入真的是一个格子的坐标，而不是随便弄的一个三维向量）
    /// </summary>
    /// <param name="WorldPos">世界坐标</param>
    /// <returns>转化后的cell坐标</returns>
    public Vector3Int WorldPosToHexPos(Vector3 WorldPos)
    {
       return new Vector3Int(0,0,0); 
    }

    /// <summary>
    /// 这个函数将hexTilemap的cell坐标（注意类型是VECTOR3INT）转化为世界坐标并返回
    /// </summary>
    /// <param name="HexPos">cell坐标</param>
    /// <returns>转化后的世界坐标</returns>
    public Vector3 HexPosToWorldPos(Vector3Int HexPos)
    {
       return new Vector3(0,0,0); 
    }

    /// <summary>
    /// 该函数将目标的地图格子的高亮模式改变（若无需高亮，传入EnumDefinition.HighlightMode.None）
    /// </summary>
    /// <param name="target">一个包含了所有的待更改格子的List<MapGrid>变量</param>
    /// <param name="highlightMode">高亮模式，可以为None</param>
    public void HighlightmapCells(List<Vector2Int> target, Inventory.HighlightMode highlightMode)
    {
        if(stateInventory.isFront){
            foreach(Vector2Int hexCoord in target)
            {
                gridInventory.frontMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().HighlightCell(highlightMode);
            }
        }else{
            foreach(Vector2Int hexCoord in target)
            {
                gridInventory.backMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().HighlightCell(highlightMode);
            }
        }
    }

    /// <summary>SAS
    /// 该函数改变一批格子的高度
    /// </summary>
    /// <param name="target">目标格子的list</param>
    /// <param name="delta">变化量</param>
    public void ChangeAltitude(List<Vector2Int> target, int delta)
    {
        if(stateInventory.isFront){
            foreach(Vector2Int hexCoord in target)
            {
                gridInventory.frontMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().altitude += delta;
                gridInventory.backMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().altitude -= delta;
            }
        }else{
            foreach(Vector2Int hexCoord in target)
            {
                gridInventory.frontMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().altitude -= delta;
                gridInventory.backMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().altitude += delta;
            }
        }    Debug.Log("???");   
    }

    /// <summary>
    /// 在一批格子上产生元素反应
    /// </summary>
    /// <param name="target">目标格子list</param>
    /// <param name="elementIn">传入的元素</param>
    public void ElementalReaction(List<Vector2Int> target, Inventory.Element elementIn)
    {
        if(stateInventory.isFront){
            foreach(Vector2Int hexCoord in target)
            {
                gridInventory.frontMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().ElementReactionOnMap(elementIn);
            }
        }else{
            foreach(Vector2Int hexCoord in target)
            {
                gridInventory.backMap[hexCoord.x,hexCoord.y].GetComponent<HexCell>().ElementReactionOnMap(elementIn);
            }
        }
    }

    /// <summary>
    /// 当棋子站在格子上时，每回合调用一次
    /// </summary>
    /// <param name="gridHexPos">格子的cell坐标</param>
    /// <param name="chess">棋子</param>
    public void OnStand(Vector3Int gridHexPos, GameObject chess)
    {
        gridInventory.frontMap[gridHexPos.x, gridHexPos.y].GetComponent<HexCell>().OnChessStand(chess);
    }

    /// <summary>
    /// 当棋子与格子交互时调用
    /// </summary>
    /// <param name="gridHexPos">格子的cell坐标</param>
    /// <param name="chess">棋子</param>
    public void OnInterface(Vector3Int gridHexPos, GameObject chess)
    {
        gridInventory.frontMap[gridHexPos.x, gridHexPos.y].GetComponent<HexCell>().OnChessInterface(chess);
    }

    /// <summary>
    /// 点击某个地图格子时调用
    /// </summary>
    /// <param name="hexPos">地图格子的cell坐标</param>
    public void OnClick(Vector3Int hexPos)
    {
        gridInventory.frontMap[hexPos.x, hexPos.y].GetComponent<HexCell>().MapGridOnClick(Inventory.HexCellClickMode.Info, 0);
    }

}
