using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (gameObject.CompareTag("Player") && collision.CompareTag("Alien"))
            GameManager.instance.onShipHit(collision);
        else if (gameObject.CompareTag("Alien") && collision.CompareTag("Player"))
            GameManager.instance.onAlienHit(gameObject, collision);
    }

}
