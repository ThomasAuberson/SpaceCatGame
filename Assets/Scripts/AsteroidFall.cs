using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFall : MonoBehaviour
{
    public float speed = 10.0f;
    private bool movingR = true;
    private float lifeTime = 1000.0f;


    void Update() {
        float mov = -Time.deltaTime * speed;
        transform.Translate(mov, mov, 0);
        lifeTime += mov;
        Debug.Log(lifeTime);
        if (lifeTime < 0) {
            Destroy(gameObject);
        };
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("BOOM!");
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }
}
