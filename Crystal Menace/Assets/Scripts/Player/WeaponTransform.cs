using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTransform : MonoBehaviour
{
    private float mSize = 0.0f;
   
    public bool HandGun = true;
    public bool ShotGun = true;
    public bool MachineGun = true;

    public bool HandGun1 = false;
    public bool ShotGun2 = false;
    public bool MachineGun3 = false;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && HandGun == true && HandGun1 == true) 
        {

            InvokeRepeating("Scale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ShotGun == true && ShotGun2 == true)
        {

            InvokeRepeating("Scale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && MachineGun == true && MachineGun3 == true)
        {

            InvokeRepeating("Scale", 0.0f, 0.01f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && HandGun == false && HandGun1 == true)
        {

            InvokeRepeating("ReverseScale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ShotGun == false && ShotGun2 == true)
        {

            InvokeRepeating("ReverseScale", 0.0f, 0.01f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && MachineGun == false && MachineGun3 == true)
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
