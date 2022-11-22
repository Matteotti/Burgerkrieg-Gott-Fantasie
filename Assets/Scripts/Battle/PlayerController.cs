using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region variables
    public int moveRange ;
    public int attackRange ;
    public int attack ;
    public bool hasMoved;
    public bool hasAttacked;
    [Tooltip("该棋子序号")]
    public int playerId;
    [Tooltip("是否被临时高亮")]
    public bool highLighted;
    [Tooltip("这是该物体的Outline Shader，以用于高亮")]
    public Material thisOutlineMaterial;

    private GameManager GameManager;
    public PieceInventory pieceInventory;
    public Inventory.Element element;
    public Inventory.Corps corp;
    public int elementAmountMax = 3;//元素量,即生命
    public int elementAmount;//当前生命
    #endregion

    public void UpdatePiece()
    {
   
    }

    /// <summary>
    /// 将这一棋子高亮
    /// </summary>
    /// <param name="highLightMode">高亮模式，可以为NONE</param>
    public void HighlightPiece(Inventory.HighlightMode highLightMode)
    {
        Outline outline = GetComponent<Outline>();
        switch (highLightMode)
        {
            case Inventory.HighlightMode.mouseTarget:
                outline.enabled = true;
                outline.color = 0;
                break;
            case Inventory.HighlightMode.attackTarget:
                break;
            case Inventory.HighlightMode.attackRange:
                break;
            case Inventory.HighlightMode.moveRange:
                break;
            case Inventory.HighlightMode.moveTarget:
                break;
            case Inventory.HighlightMode.None:
                outline.enabled = false;
                break;
        }
    }
    public void Move()
    {

        GameManager.CloseMoveRange();
    }

    public void Attack()
    {

    }

    void Start()
    {
        //GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //初始化生命
        elementAmount = elementAmountMax;
        //更新兵种相关属性
        moveRange = corp switch
        {
            Inventory.Corps.soldier => 4,
            Inventory.Corps.archer => 3,
            Inventory.Corps.scouts => 4,
            Inventory.Corps.crossbowman => 2,
        };
        attackRange = corp switch
        {
            Inventory.Corps.soldier => 1,
            Inventory.Corps.archer => 3,
            Inventory.Corps.scouts => 1,
            Inventory.Corps.crossbowman => 4,
        };

    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GameManager.selected = this.gameObject;
        GameManager.ShowMoveRange();
    }
 
}
