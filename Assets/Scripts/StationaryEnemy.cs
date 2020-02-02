using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour
{
    private LevelController levelController;

    private bool triggered = false;
    private float timeToDeath = 2f;

    // Start is called before the first frame update
    void Start() {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    private void Update() {
        if (triggered && timeToDeath >= 0) {
            float dt = Time.deltaTime;
            timeToDeath -= dt;
            if (timeToDeath <= 0) {
                levelController.EndGameDeath();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
        if (pm != null && !triggered) {
            Debug.Log("Death By Stationaary Enemy");
            pm.enabled = false;
            triggered = true;
        }
    }
}
