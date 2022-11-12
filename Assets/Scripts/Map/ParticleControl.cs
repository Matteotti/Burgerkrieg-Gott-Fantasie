using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ParticleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //修改粒子系统的模型，让它从父对象表面发出
        //这种在新变量修改的方法非常的不合常理，但确实是这样。参见https://blog.csdn.net/BDDNH/article/details/103728429
        ParticleSystem.ShapeModule shapeModule = gameObject.GetComponent<ParticleSystem>().shape;
        shapeModule.mesh = gameObject.transform.parent.gameObject.GetComponent<MeshFilter>().sharedMesh;
        
    }
        
}
