using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个类储存了所有与棋子相关的素材如预制体特效等
[CreateAssetMenu(fileName = "NewPieceInventory", menuName = "Piece/PieceInventory")]//将新建物体的选项添加至unity右键菜单
public class PieceInventory : ScriptableObject
{
    [System.Serializable]
    public struct Piece{
        public Mesh mesh;
        public Material material;
    };
    [Tooltip("这里是不同棋子的mesh文件")]
    public Piece soldier,//战士
        archer,//弓手
        scouts,//斥候
        crossbowman;//重弩手;

}