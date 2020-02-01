
using System.Collections;
using System.Collections.Generic;
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

    public LevelSection[] levelSections;
    public int startSectionIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(0, 20);
    }



    public void GenerateLevel(int difficulty, int sections) {
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

        int x = 0;
        int y = 0;
        for(int i = 0; i < sections; i++) {
            int rand = (i == 0)? startSectionIndex : Random.Range(0, levelDraw.Count);
            LevelSection levelSection = levelDraw[rand];

            Instantiate(levelSection.prefab, new Vector3(x, y, 0), Quaternion.identity, transform);
            y += levelSection.deltaY;
            x += levelSection.deltaX;
        }


    }

    public void RepairPartCollected() {
        Debug.Log("Repair Part Colelcted!");
    }

    public void EndGameDeath() {
        Debug.Log("Player Died");
        SceneManager.LoadSceneAsync("DeathScreen");
    }
}
