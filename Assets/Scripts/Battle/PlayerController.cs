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
    [Tooltip("���������")]
    public int playerId;
    [Tooltip("�Ƿ���ʱ����")]
    public bool highLighted;
    [Tooltip("���Ǹ������Outline Shader�������ڸ���")]
    public Material thisOutlineMaterial;

    private GameManager GameManager;
    public PieceInventory pieceInventory;
    public Inventory.Element element;
    public Inventory.Corps corp;
    public int elementAmountMax = 3;//Ԫ����,������
    public int elementAmount;//��ǰ����
    #endregion

    public void UpdatePiece()
    {
   
    }

    /// <summary>
    /// ����һ���Ӹ���
    /// </summary>
    /// <param name="highLightMode">����ģʽ������ΪNONE</param>
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
        //��ʼ������
        elementAmount = elementAmountMax;
        //���±����������
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
