using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class AlienPositionFormationBehaviour : MonoBehaviour
{
    public AlienType alienType;
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, .2f);
    }
}
