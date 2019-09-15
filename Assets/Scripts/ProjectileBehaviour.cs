using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 startPosition;

    [SerializeField] protected double maxDistance;
   
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.magnitude > 0)
            if (Vector2.Distance(transform.position, startPosition) > maxDistance)            
                Destroy(gameObject);         
    }

    public void Shoot(Vector2 startPosition, Vector2 direction, float speed){
        this.startPosition = startPosition;
        transform.position = startPosition;
        rigidbody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (Vector2.Distance(startPosition, collision.transform.position) > 3) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
