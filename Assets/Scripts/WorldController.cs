using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public int TallTileHeight = 25;
    public int StartOffsetX = 100;
    public GameObject TallDirtTilePrefab;



    // Start is called before the first frame update
    void Start()
    {
        int[] elevationMap = GenerateElevationMap(10000,100);


        int yOffSet = elevationMap[0];

        for (int x =  0; x < elevationMap.Length; x++) {            
            Instantiate(TallDirtTilePrefab, new Vector3(x, elevationMap[x], 0), Quaternion.identity, transform);            
        }
    }

    private int[] GenerateElevationMap(int length, int yMax) {
        float seed = Random.Range(0f, 20000f);

        int[] elevationMap = new int[length];
        float yOffset = 0f;
        for(int x = 0; x < length; x++) {
            float y =
                //Random.Range(0f, 2f) +
                (Mathf.PerlinNoise(x * 0.05f, seed) * 10) +
                (Mathf.PerlinNoise(x * 0.005f, seed) * 100) +
                //(Mathf.PerlinNoise(x * 0.0005f, seed) * 1000);
                - yOffset;
            if (x == 0){
                yOffset = y;
                y = 0f;
            }
            elevationMap[x] = (int)y- TallTileHeight;
        }
        return elevationMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
