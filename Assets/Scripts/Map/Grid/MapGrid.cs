using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{

    #region ����
    [Tooltip("���Ǹýű����õĳ־û���Դ�����ɱ����ģ����������GridBase")]
    public MapGridBase baseGrid;
    [Tooltip("���Ǹýű��Լ���MapUnit���ԣ�Ӧ�ø��ĵ������")]
    public MapGridBase thisGrid;
    [Tooltip("���ӵ�����sprite�زģ���Ч������ϵͳԤ����ȶ����������")]
    public GridInventory inventory;
    [Tooltip("���Ǹ������Outline Shader�������ڸ�����ע����Ҫʵ����һ��֮���ٸ��ģ���Ȼ�Ļ����е�shader���ᱻ�ģ��ѷ�װ�����ùܣ�")]
    public Material thisOutlineMaterial;
    #endregion

    #region Map����Ҫ���õķ���
    /// <summary>
    /// ����ȫ�ֱ���thisGrid�����µ�ǰ��ͼ��Ԫ
    /// </summary>
    public void UpdateGrid()
    {
        /*�������Ԫ�أ������Ԫ��ᱻʩ����Ч
         *��Ԫ���Ӧ��ģ�Ͳ��ʵ���Դ���ã��ɸ߶Ⱥ͸����ĵ�Ԫ��ͬ����������߶���ͬ������ɽ�����γ�ɽ����
         *��ЩҲ��Ҫ���£��һ�ûд
         *�������ﲻ��������״̬�ĸ���
         */
        switch (thisGrid.altitude)
        {
            case -3:
                thisGrid.gridSprite = inventory.mountain3;
                break;
            case -2:
                thisGrid.gridSprite = inventory.hill2;
                break;
            case -1:
                thisGrid.gridSprite = inventory.hill1;
                break;
            case 0:
                thisGrid.gridSprite = inventory.ground0;
                break;
            case 1:
                thisGrid.gridSprite = inventory.basin_1;
                break;
            case 2:
                thisGrid.gridSprite = inventory.valley_2;
                break;
            case 3:
                thisGrid.gridSprite = inventory.pit_3;
                break;
            default:
                thisGrid.gridSprite = inventory.hole;
                break;
        }//��ͬ�ĸ߶ȶ�Ӧ��ͬ����ͼ��֮�������ͼ
        GetComponent<SpriteRenderer>().sprite = thisGrid.gridSprite;
    }
    /// <summary>
    /// ����һ���ͼ���Ӹ���
    /// </summary>
    /// <param name="highLightMode">����ģʽ������ΪNONE</param>
    public void HighlightGrid(EnumDefinition.HighlightMode highLightMode)
    {
        switch (highLightMode)
        {
            case EnumDefinition.HighlightMode.mouseTarget:
                thisOutlineMaterial.SetColor("lineColor", Color.grey);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.attackTarget:
                thisOutlineMaterial.SetColor("lineColor", Color.red);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.attackRange:
                thisOutlineMaterial.SetColor("lineColor", Color.green);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.moveRange:
                thisOutlineMaterial.SetColor("lineColor", Color.blue);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.moveTarget:
                thisOutlineMaterial.SetColor("lineColor", Color.black);
                thisOutlineMaterial.SetFloat("lineWidth", 20);
                break;
            case EnumDefinition.HighlightMode.None:
                thisOutlineMaterial.SetFloat("lineWidth", 0);
                break;
        }
    }
    /// <summary>
    /// ��ͼ�ϵ�Ԫ�ط�Ӧ������ĳԪ�أ��ı�Element��������Ӧ�����ﵽĳЧ��
    /// </summary>
    /// <param name="elementIn">�����Ԫ��</param>
    public void ElementReactionOnMap(EnumDefinition.Element elementIn)
    {

    }
    /// <summary>
    /// С��վ�ڸø�����ʱ��ÿ�غ�ִ��һ��
    /// </summary>
    /// <param name="chess">վ�����������</param>
    public void OnChessStand(GameObject chess)
    {

    }
    /// <summary>
    /// С����ø��ӽ���ʱִ��һ��
    /// </summary>
    /// <param name="chess">��֮����������</param>
    public void OnChessInterface(GameObject chess)
    {

    }
    /// <summary>
    /// ������ø���ʱִ�У�Ҳ������ʾ��Ϣ��
    /// </summary>
    public void MapGridOnClick()
    {

    }
    #endregion

    #region �Լ���Ҫ���õķ���
    /// <summary>
    /// ���������������һ��������material��������������ĳһ��gameobject��material��������ȫ������  
    /// </summary>
    void MaterialInitialize()
    {
        thisOutlineMaterial = Instantiate(thisOutlineMaterial);
        GetComponent<SpriteRenderer>().material = thisOutlineMaterial;
    }
    #endregion

    private void Start()
    {
        MaterialInitialize();
        UpdateGrid();//�ű�ʵ����ʱ����һ�θ���
    }
}
