using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个类用来记录土木技能的种类和进行土木技能的释放
//如果需要全局调整的数值之类，可以再搞个 SkillInventory
public class BurgerkriegSkills : MonoBehaviour
{
    public Inventory inventory;
    public StateInventory stateInventory;
    public GameObject map;
    MapInterface mapInterface;

    public void UseSkill(Vector2Int hexTarget){
        if(stateInventory.burgerkreigState == StateInventory.BurgerkreigState.Rest){return;}
        
        switch (stateInventory.burgerkreigState){
            case StateInventory.BurgerkreigState.MountCreate: 
                MountCreate(hexTarget);
                
                break;

        }
        stateInventory.burgerkreigState = StateInventory.BurgerkreigState.Rest;//finish and reset te state
    }

    public void MountCreate(Vector2Int hexTarget){
        List<Vector2Int> targetList = new List<Vector2Int>();
        //Debug.Log(targetList.Count);
        targetList.Add(hexTarget);
        //Debug.Log(targetList.Count);
        mapInterface.ChangeAltitude(targetList, 1);
    }

    void Start(){
        mapInterface = map.GetComponent<MapInterface>();
    }
}
