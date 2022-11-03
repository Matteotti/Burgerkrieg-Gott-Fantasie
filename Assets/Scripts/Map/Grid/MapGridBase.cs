using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����ඨ���˵�ͼ���ӵĳ�����Чʲôʲô��֮�����������
[CreateAssetMenu(fileName = "NewMapGridBase", menuName = "Map/NewGridBase")]//���½������ѡ�������unity�Ҽ��˵�
public class MapGridBase : ScriptableObject
{
    /*�Ҷ�texture��material��һ�鲻̫��Ϥ����Ŀ
     * �������µĲ�����ʱûд
     * private elemental//Ԫ�أ��������Ԫ�أ������Ԫ��ᱻʩ����Ч����Ҫ��һ����ɫmask�����ӣ�
     * {
     * element;
     * mask;
     * particales;
     * };
     * private model//��Ԫ���Ӧ��ģ�Ͳ��ʵ���Դ���ã��ɸ߶Ⱥ͸����ĵ�Ԫ��ͬ����������߶���ͬ������ɽ�����γ�ɽ����
     * {
     * meshRef
     * materialRef
     * };
     */
    [Tooltip("�õ�Ԫ��߶�")]
    public int altitude;
    [Tooltip("�Ƿ���ʱ����")]
    public bool hightLighted;
    [Tooltip("��HexTilemap�������")]
    public Vector3Int hexPos;
    [Tooltip("��������")]
    public Vector3 worldPos;
    [Tooltip("������߷���")]
    public bool isOnTheFrontSide;
    [Tooltip("�ɸ߶Ⱦ��������Ҫ���������������������Ӧ������Ϊanimator")]
    public Sprite gridSprite;
    [Tooltip("����������Ԫ�أ�����ΪNONE")]
    public EnumDefinition.Element gridElement;
    [Tooltip("����������ǲ������ظ��ӻ���Ҫ�����߱��ʲô����Ч��������ΪNONE")]
    public EnumDefinition.SpecialGridType specialGridType;
}
