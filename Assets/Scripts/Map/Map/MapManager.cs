using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [Tooltip("HexTilemap for frontMap")]
    public Map front;
    [Tooltip("HexTilemap for backMap")]
    public Map back;
    
}