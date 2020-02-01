using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPart : MonoBehaviour
{
    private LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {        
        levelController.RepairPartCollected();
        Destroy(gameObject);
    }
}
