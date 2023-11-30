using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
 
{
    public float speed;
    private Rigidbody enemyrb;
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10) { Destroy(gameObject); }
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyrb.AddForce( lookDirection * speed);
    }
}
