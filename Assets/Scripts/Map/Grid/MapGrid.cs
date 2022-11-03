using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [Tooltip("���Ǹýű����õĳ־û���Դ�����ɱ����ģ����������GridBase")]
    public MapGridBase baseGrid;
    [Tooltip("���Ǹýű��Լ���MapUnit���ԣ�Ӧ�ø��ĵ������")]
    public MapGridBase thisGrid;
    [Tooltip("���ӵ�����sprite�زģ���Ч������ϵͳԤ����ȶ����������")]
    public GridInventory inventory;
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
        switch(thisGrid.altitude)
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
}
