using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
   

    public int Score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //Debug.Log("enemy collided with collector");
            Score += 10;
            
        }
    }

}
