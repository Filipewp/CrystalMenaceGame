using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTransform : MonoBehaviour
{
    private float mSize = 0.0f;
   
    public bool HandGun = true;
    public bool ShotGun = true;
    public bool MachineGun = true;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && HandGun == true)
        {

            InvokeRepeating("Scale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ShotGun == true)
        {

            InvokeRepeating("Scale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && MachineGun == true)
        {

            InvokeRepeating("Scale", 0.0f, 0.01f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && HandGun == false)
        {

            InvokeRepeating("ReverseScale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ShotGun == false)
        {

            InvokeRepeating("ReverseScale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && MachineGun == false)
        {

            InvokeRepeating("ReverseScale", 0.0f, 0.01f);
        }
    }
    void Scale()
    {
        if (mSize >= 100.0f)
        {
            CancelInvoke("Scale");
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize++);
       
    }

    void ReverseScale()
    {
        if (mSize <= 0f)
        {
            CancelInvoke("ReverseScale");
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize--);

    }
}
