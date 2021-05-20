using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerCrystal : MonoBehaviour
{

    private float mSize = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Scale", 0.0f, 0.01f);
    }

    void Scale()
    {
        if(mSize >= 100.0f)
        {
            CancelInvoke("Scale");
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(2, mSize++);
        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(3, mSize++);
    }
}
