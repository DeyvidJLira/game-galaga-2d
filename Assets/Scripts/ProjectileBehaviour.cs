using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;
   
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector2 startPosition, Vector2 direction, float speed){
        transform.position = startPosition;
        rigidbody.velocity = direction * speed;
    }
}
