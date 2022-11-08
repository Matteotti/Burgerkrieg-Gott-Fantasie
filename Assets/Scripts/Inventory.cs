using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
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

    public float hexEdgeLength = 1.0f;
}
