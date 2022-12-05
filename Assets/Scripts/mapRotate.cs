using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRotate : MonoBehaviour
{
    private bool mapRotateTriger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }
    
    private void OnTriggerEnter(Collider other)
    { 
        if (other.name == "unito")
        {
            mapRotateTriger = !mapRotateTriger;
        /*
            var target = Quaternion.Euler(new Vector3(0, mapRotateMax, 0));
            other.transform.rotation =
                Quaternion.Slerp(transform.rotation, target, Time.deltaTime * mapRoateSmooth);
        */
        }
    }

    public bool RotateCheck()
    {
        return mapRotateTriger;
    }
}
