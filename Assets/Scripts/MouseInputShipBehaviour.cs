using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputShipBehaviour : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }
}
