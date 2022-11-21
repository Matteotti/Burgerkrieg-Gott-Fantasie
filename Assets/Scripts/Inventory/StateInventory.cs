using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class is used to store the states when gameplaying
[CreateAssetMenu(fileName = "StateInventory", menuName = "Inventory/StateInventory")]
public class StateInventory : ScriptableObject
{
    [Tooltip("if the player is seeing the front map")]
    public bool isFront;

    public enum BurgerkreigState{
        Rest,
        MountCreate
    }
    [Tooltip("states about using burgerkreig skills")]
    public BurgerkreigState burgerkreigState = BurgerkreigState.Rest;
}
