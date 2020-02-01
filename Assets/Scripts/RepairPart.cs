using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPart : MonoBehaviour
{
    private LevelController levelController;
    private MinigameController minigameController;

    // Level Stuff
    private bool triggered = false;
    private float timeDelay = 1.0f;

    // Minigame stuff
    private Vector2 targetL = new Vector2(-90,40);
    private Vector2 targetR = new Vector2(90, 40);
    private bool movingR = true;
    private bool falling = false;
    private bool collided = false;

    // Start is called before the first frame update
    void Start() {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        minigameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MinigameController>();

    }

    private void Update() {
        if (levelController != null) {
            // Level Mode
            if (triggered && timeDelay >= 0) {
                float dt = Time.deltaTime;
                transform.Translate(0f, -2f * dt, 0f);
                timeDelay -= dt;
                if (timeDelay <= 0) {
                    levelController.StartMinigame();
                }
            }
        } else if (minigameController != null) {
            if (Input.GetButtonDown("Jump")) {
                falling = true;
            }
            // Minigame mode
            if (falling) {
                transform.Translate(0, -Time.deltaTime * minigameController.partFallSpeed, 0);
            } else {
                transform.position = Vector2.MoveTowards(transform.position, (movingR ? targetR : targetL), Time.deltaTime * minigameController.partSpeed);
                if (Vector2.Distance(transform.position, (movingR ? targetR : targetL)) < 0.5f) {
                    movingR = !movingR;
                }

            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision) {
        
        if (levelController != null) {
            // Level Mode
            PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
            if (pm != null && !triggered) {
                //Destroy(gameObject);
                GetComponentInChildren<SpriteRenderer>().enabled = false;
                Debug.Log("Found Part");
                pm.enabled = false;
                triggered = true;
            }
        }
        else if(minigameController != null) {
            // Minigame mode
            if (collided == false) {
                collided = true;
                if (collision.gameObject.tag == "Ship") {
                    minigameController.MinigameSuccess();
                    Destroy(gameObject);

                } else {
                    minigameController.MinigameFail();
                }
            }
        }
    }
}
