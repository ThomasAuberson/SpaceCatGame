using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public int minY = 10;
    public int LockY = 12;
    public int HeightDiffBeforeFollow = 30;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float newy = LockY;
        //float newy = player.transform.position.y + offset.y;
        //if(player.transform.position.y > transform.position.y+HeightDiffBeforeFollow){
        //    newy = player.transform.position.y + offset.y - HeightDiffBeforeFollow;
        //}

        //if(newy < minY){
        //    newy = minY;
        //}

        transform.position = new Vector3 (player.transform.position.x + offset.x, newy , offset.z); // Camera follows the player with specified offset position
    }
}
