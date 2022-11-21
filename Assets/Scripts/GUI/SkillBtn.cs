using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkillBtn : MonoBehaviour, IPointerDownHandler
{
    public StateInventory stateInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData){
        stateInventory.burgerkreigState = StateInventory.BurgerkreigState.MountCreate;
    }
}
