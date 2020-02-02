using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    public float speed = 2.0f;
    private bool movingR = true;
    public Transform LeftBuoy;
    public Transform RightBuoy;


    void Update() {
        transform.Translate(Time.deltaTime * (movingR?speed:-speed), 0, 0);        
        if (Vector3.Distance(transform.position, (movingR ? RightBuoy.position : LeftBuoy.position)) < 0.5f) {
            movingR = !movingR;            
            transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
        }
    }
}
