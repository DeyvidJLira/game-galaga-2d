using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootinProjectileBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float projectileSpeed;

    protected GameObject projectileTemp;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            projectileTemp = Instantiate(projectilePrefab);
            projectileTemp.GetComponent<ProjectileBehaviour>().Shoot(transform.position, Vector2.up, projectileSpeed);
        }
    }
}
