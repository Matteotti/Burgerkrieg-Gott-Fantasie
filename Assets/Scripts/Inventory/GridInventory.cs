using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个类储存了所有与地图格子相关的素材如sprite粒子系统预制体特效等
[CreateAssetMenu(fileName = "NewMapGridInventory", menuName = "Map/NewMapGridInventory")]//将新建物体的选项添加至unity右键菜单
public class GridInventory : ScriptableObject
{
    [Tooltip("这里是不同地形的sprite文件，前面是名字后面是高度绝对值,带有“_”的表示高度是负数")]
    public Sprite mountain3, hill2, hill1, ground0, basin_1, valley_2, pit_3, hole;
}
