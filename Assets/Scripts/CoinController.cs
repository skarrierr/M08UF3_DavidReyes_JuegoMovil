using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);  
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
       
    }
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pelota")
        {
            gameManager.coins++;
            Destroy(gameObject);
        }
    }
}
