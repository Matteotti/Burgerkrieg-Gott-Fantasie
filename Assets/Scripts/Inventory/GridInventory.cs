using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����ഢ�����������ͼ������ص��ز���sprite����ϵͳԤ������Ч��
[CreateAssetMenu(fileName = "NewMapGridInventory", menuName = "Map/NewMapGridInventory")]//���½������ѡ�������unity�Ҽ��˵�
public class GridInventory : ScriptableObject
{
    [Tooltip("�����ǲ�ͬ���ε�sprite�ļ���ǰ�������ֺ����Ǹ߶Ⱦ���ֵ,���С�_���ı�ʾ�߶��Ǹ���")]
    public Sprite mountain3, hill2, hill1, ground0, basin_1, valley_2, pit_3, hole;
}
