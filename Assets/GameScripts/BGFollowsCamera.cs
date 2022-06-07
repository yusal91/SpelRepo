using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollowsCamera : MonoBehaviour
{
    public Transform followCamera;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(followCamera.transform.position.x, followCamera.transform.position.y, transform.position.z); 
    }

   
}
