using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null)
        {
            return; 
        }

        tempPos = transform.position; // setting camera's current position into tempPos
        tempPos.x = player.position.x; // changing only the x position of that into the x position of the player

        if (tempPos.x < minX)
        {
            tempPos.x = minX; 
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX; 
        }
        // setting bounds
        transform.position = tempPos; // changing the camera's position to the new value assigned to tempPos
    }
}
