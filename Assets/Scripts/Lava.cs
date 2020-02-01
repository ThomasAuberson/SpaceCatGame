using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private LevelController levelController;

    private bool triggered = false;
    private float timeToDeath = 3.0f;

    // Start is called before the first frame update
    void Start() {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    private void Update() {
        if (triggered && timeToDeath >= 0) {
            float dt = Time.deltaTime;
            transform.Translate(0f, -2f*dt, 0f);
            timeToDeath -= dt;
            if (timeToDeath <= 0) {
                levelController.EndGameDeath();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
        if (pm!=null && !triggered) {
            Debug.Log("Death By Lava");
            pm.enabled = false;
            triggered = true;
        }
    }
}
