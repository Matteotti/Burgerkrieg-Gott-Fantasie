using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个类定义了地图格子的除了特效什么什么的之外的所有属性
[CreateAssetMenu(fileName = "NewMapGridBase", menuName = "Map/NewGridBase")]//将新建物体的选项添加至unity右键菜单
public class MapGridBase : ScriptableObject
{
    /*我对texture和material这一块不太熟悉（泪目
     * 所以以下的部分暂时没写
     * private elemental//元素，如果存在元素，这个单元格会被施加特效（主要是一个变色mask和粒子）
     * {
     * element;
     * mask;
     * particales;
     * };
     * private model//单元格对应的模型材质等资源引用，由高度和附近的单元格共同决定（比如高度相同的两座山连着形成山脉）
     * {
     * meshRef
     * materialRef
     * };
     */
    [Tooltip("该单元格高度")]
    public int altitude;
    [Tooltip("是否被临时高亮")]
    public bool hightLighted;
    [Tooltip("在HexTilemap里的坐标")]
    public Vector3Int hexPos;
    [Tooltip("世界坐标")]
    public Vector3 worldPos;
    [Tooltip("正面或者反面")]
    public bool isOnTheFrontSide;
    [Tooltip("由高度决定，如果要做动画，这个变量的属性应被更改为animator")]
    public Sprite gridSprite;
    [Tooltip("格子所带的元素，可以为NONE")]
    public EnumDefinition.Element gridElement;
    [Tooltip("决定这个格是不是神秘格子或者要塞或者别的什么特殊效果，可以为NONE")]
    public EnumDefinition.SpecialGridType specialGridType;
}
