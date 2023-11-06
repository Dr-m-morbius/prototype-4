using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class rotatecam : MonoBehaviour
{
    public float rotationSpeed = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);
    }
}
