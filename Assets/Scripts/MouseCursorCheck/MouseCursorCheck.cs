using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorCheck : MonoBehaviour
{
    GameObject lastGameObject;//上一个被射线检测到的物体，用来让上一个物体的高亮消失
    private void Start()
    {
        lastGameObject = null;
    }
    void Update()
    {
        //通过鼠标位置获取射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //通过射线获取碰撞信息
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //如果碰撞体的tag是cell
            if (hit.collider.tag == "Cell")
            {
                //获取碰撞体的高亮组件
                HexCell hexCell = hit.collider.GetComponent<HexCell>();
                //如果上一个被射线检测到的物体不为空，且不是当前被射线检测到的物体
                if (lastGameObject != null && lastGameObject != hit.collider.gameObject)
                {
                    //让上一个物体的高亮消失
                    lastGameObject.GetComponent<HexCell>().HighlightCell(Inventory.HighlightMode.None);
                }
                //让当前物体的高亮显示
                hexCell.HighlightCell(Inventory.HighlightMode.mouseTarget);
                //将当前物体赋值给上一个物体
                lastGameObject = hit.collider.gameObject;
            }
            //如果碰撞体的tag不是cell
            else
            {
                //如果上一个被射线检测到的物体不为空
                if (lastGameObject != null)
                {
                    //让上一个物体的高亮消失
                    lastGameObject.GetComponent<HexCell>().HighlightCell(Inventory.HighlightMode.None);
                }
            }
            //如果鼠标左键按下
            if (Input.GetMouseButtonDown(0))
            {
                //如果碰撞体的tag是cell
                if (hit.collider.tag == "Cell")
                {
                    hit.collider.GetComponent<HexCell>().MapGridOnClick(Inventory.HexCellClickMode.Info, 0);
                    //进行土木技能释放检测
                    //Debug.Log("SKILL");
                    gameObject.GetComponent<BurgerkriegSkills>().UseSkill(hit.collider.gameObject.GetComponent<HexCell>().hexCoord);
                }
            }
        }
        else
        {
            //如果上一个被射线检测到的物体不为空
            if (lastGameObject != null)
            {
                //让上一个物体的高亮消失
                lastGameObject.GetComponent<HexCell>().HighlightCell(Inventory.HighlightMode.None);
            }
        }
    }
}
