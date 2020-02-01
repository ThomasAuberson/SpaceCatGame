using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour
{

    public float partSpeed = 50.0f;
    public float partFallSpeed = 50.0f;

    public TextMeshProUGUI resultText;

    private bool triggered = false;
    private float timeToDeath = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Minigame");
    }

    // Update is called once per frame
    void Update() {
        if (triggered && timeToDeath >= 0) {
            float dt = Time.deltaTime;
            transform.Translate(0f, -2f * dt, 0f);
            timeToDeath -= dt;
            if (timeToDeath <= 0) {
                SceneManager.LoadSceneAsync("MainScene");
            }
        }
    }

    public void MinigameSuccess() {
        Debug.Log("Minigame Success");
        resultText.text = "Success!";
        Databank.repairProgress++;
        Databank.levelNumber++;
        triggered = true;
    }

    public void MinigameFail() {
        Debug.Log("Minigame Fail");
        resultText.text = "Failed... part lost :(";
        Databank.levelNumber++;
        triggered = true;
    }
}
