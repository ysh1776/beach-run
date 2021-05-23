using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    private Transform lookAt;
    public Vector3 startOffset;
    GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("VRUI");
        
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookAt.position + startOffset;
        ui.transform.position = new Vector3(-51.0f, 0f, transform.position.z+90.0f);

    }
}
