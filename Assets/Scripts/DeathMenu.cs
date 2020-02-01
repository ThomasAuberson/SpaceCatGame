﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame() {
        Debug.Log("Restart Game");
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void QuitGame() {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
