using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [Tooltip("正面地图的HexTilemap")]
    public Map front;
    [Tooltip("反面地图的HexTilemap")]
    public Map back;
    
}