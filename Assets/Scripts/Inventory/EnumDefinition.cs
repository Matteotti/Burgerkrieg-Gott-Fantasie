using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnumDefinition
{
    public enum Element
    {
        Fire,
        Water,
        Thunder,
        Ice,
        Ground,
        None
    }
    public enum SpecialGridType
    {
        MysteriousGrid,
        Fortress,
        ElementGrid,
        None
    }
    public enum HighlightMode
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
}
