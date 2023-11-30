using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    public float speed = 5f;
    public bool haspower;

    private GameObject focalPoint;
    private Rigidbody playerRb;
    private float powerupStrength = 100.0f;
    public GameObject powerindicator;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("fp");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerindicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            powerindicator.SetActive(true);
            haspower = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());

           
        }
             IEnumerator PowerCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            haspower = false;
            powerindicator.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.CompareTag("enemy") && haspower)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with: " + collision.gameObject.name + " with power set to " + haspower);
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }  
    }
}
