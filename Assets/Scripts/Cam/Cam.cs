using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    Quaternion initRot;
    // Start is called before the first frame update
    void Start()
    {
        initRot = transform.rotation;
    }
    private void LateUpdate()
    {
        transform.rotation = initRot;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
