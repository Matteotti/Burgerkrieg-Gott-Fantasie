using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个类储存了:
//1.所有与地图格子相关的素材如sprite粒子系统预制体特效等
//2.地图格子索引
[CreateAssetMenu(fileName = "GridInventory", menuName = "Inventory/GridInventory")]//将新建物体的选项添加至unity右键菜单
public class GridInventory : ScriptableObject
{   
    [System.Serializable]
    public struct Cell{
        public Mesh mesh;
        public Material material;
    };
    [Tooltip("这里是不同地形的mesh文件，前面是名字后面是高度绝对值,带有“_”的表示高度是负数")]
    public Cell mountain3, hill2, hill1, ground0, pit_1, basin_2, valley_3, hole;


    [System.Serializable]
    public struct ElementEffects{
        public GameObject red;
        public GameObject blue;
        public GameObject green;
        public GameObject yellow;
    }
    [Tooltip("Here are the particleEffects(or somthing else) for cells with different elements")]
    public ElementEffects elementEffects;



    [Tooltip("Here is a map index, indexing the hexcells using hex coords")]
    public GameObject[,] frontMap = new GameObject[100,100];//2D array cannot be seen in herarchy
    public GameObject[,] backMap;
}