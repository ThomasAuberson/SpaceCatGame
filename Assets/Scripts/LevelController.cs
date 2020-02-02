
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [System.Serializable]
    public struct LevelSection {
        public GameObject prefab;
        public int deltaY;
        public int deltaX;
        public int frequency;
        public int minSpacing; // Does not do anything yet
        public int minDifficulty;
        public int maxDifficulty;
    }

    public LevelSection[] finalSections;
    public LevelSection[] levelSections;
    private int startSectionIndex = 0;
    public TextMeshProUGUI messageText;
    private float textDelay = 0f;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(Databank.levelNumber, Databank.levelSize);
        displayMsg("Search for parts to repair your ship!\nParts found: " + Databank.repairProgress);

    }

    private void Update() {
        if (textDelay > 0) {
            textDelay -= Time.deltaTime;
            if (textDelay <= 0) {
                messageText.text = "";
            }
        }
    }

    public void displayMsg(string msg) {
        messageText.text = msg;
        textDelay = 3.0f;
    }

    public void GenerateLevel(int difficulty, int sections) {
        Debug.Log("Generate Level " + difficulty);
        List<LevelSection> levelDraw = new List<LevelSection>();
        foreach (LevelSection levelSection in levelSections) {
            if(levelSection.minDifficulty == 0 || difficulty >= levelSection.minDifficulty) {
                if (levelSection.maxDifficulty == 0 || difficulty <= levelSection.maxDifficulty) {
                    int freq = levelSection.frequency;
                    for (int i = 0; i < freq; i++) {
                        levelDraw.Add(levelSection);
                    }
                }
            }
        }

        int x = -100;
        int y = 0;
        for(int i = 0; i < sections; i++) {
            LevelSection levelSection = (i == 0) ? levelSections[startSectionIndex] :levelDraw[Random.Range(0, levelDraw.Count)];

            x += levelSection.deltaX / 2;
            Instantiate(levelSection.prefab, new Vector3(x, y, 0), Quaternion.identity, transform);
            y += levelSection.deltaY;
            x += levelSection.deltaX / 2;
        }
        // Final Section
        {
            LevelSection levelSection = finalSections[Random.Range(0, finalSections.Length)];
            x += levelSection.deltaX / 2;
            Instantiate(levelSection.prefab, new Vector3(x, y, 0), Quaternion.identity, transform);
        }
    }

    public void StartMinigame() {
        Debug.Log("RepairMinigameScene");
        SceneManager.LoadSceneAsync("RepairMinigameScene");
    }

    public void EndGameDeath() {
        Debug.Log("Player Died");
        SceneManager.LoadSceneAsync("DeathScreen");
    }
}
