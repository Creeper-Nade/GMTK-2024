using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboardrotation : MonoBehaviour
{
    Camera main_camera;
    // Start is called before the first frame update
    void Start()
    {
        main_camera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //billboard rotation
        Vector3 targetvector= this.transform.position-main_camera.transform.position;
        transform.rotation=Quaternion.LookRotation(targetvector,main_camera.transform.rotation*Vector3.up);
    }
}
