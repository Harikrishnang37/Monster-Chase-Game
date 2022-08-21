using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
{

    [SerializeField]
    private GameObject LeftCollector;
    [SerializeField]
    private GameObject RightCollector;
    [SerializeField]
    private Text ScoreBoard;
    private bool Alive;

    private int TotalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(GameObject.FindWithTag("Player") == null))
        {
            Alive = GameObject.FindWithTag("Player").GetComponent<Player>().isAlive;

            if (Alive == true)
            {
                int LeftScore = LeftCollector.GetComponent<Collector>().Score;
                int RightScore = RightCollector.GetComponent<Collector>().Score;
                TotalScore = RightScore + LeftScore;
                
                ScoreBoard.text = "Score : " + TotalScore;
            }
        }
    }
}
