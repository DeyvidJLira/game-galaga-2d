using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShootMoveBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected Transform alienBody;

    protected GameObject projectileTemp;

    public void shoot() {
        projectileTemp = Instantiate(projectilePrefab);
        projectileTemp.GetComponent<ProjectileBehaviour>().Shoot(alienBody.position, Vector2.down, projectileSpeed);
    }
}
