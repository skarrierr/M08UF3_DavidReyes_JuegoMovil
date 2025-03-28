using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);  
    public GameManager gameManager;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pelota")
        {
            Destroy(gameObject);
        }
    }
}
