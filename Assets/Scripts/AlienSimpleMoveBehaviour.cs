using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSimpleMoveBehaviour : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("flyMove", Random.Range(5,10));
    }

   protected void flyMove() {
        animator.SetTrigger("attack");

        Invoke("flyMove", Random.Range(5, 10));
    }
}
