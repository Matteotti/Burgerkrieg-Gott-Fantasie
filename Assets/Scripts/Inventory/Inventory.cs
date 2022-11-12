using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
//这个类储存了所有的大部分脚本都要用到的信息如枚举定义，数据配置等
public class Inventory : ScriptableObject
{
    public enum Element //this is the element types 
    {
        Fire,
        Water,
        Thunder,
        Ice,
        Ground,
        None
    }


    public enum SpecialCellType //this is the special map cell types
    {
        MysteriousCell,
        Fortress,
        ElementCell,
        None
    }

    public enum HighlightMode //this is the possible highlight modes of a map cell
    {
        mouseTarget,
        moveRange,
        moveTarget,
        attackRange,
        attackTarget,
        skillRange,
        skillTarget,
        None
    }
    
    public enum HexCellClickMode
    {
        Info,
        Altitude,
        Element,
        Target
    }

    public float hexEdgeLength = 1.0f;
}
