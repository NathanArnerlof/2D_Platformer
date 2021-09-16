using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Star : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            collision.GetComponent<PlayerState>().StarPickup();
            Destroy(gameObject);
        }
    }

}
