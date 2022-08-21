using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // delay time between each time the loop runs
            randomIndex = Random.Range(0, monsterReference.Length); // selecting one of the enemies from the array
            //Debug.Log(randomIndex);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {//spawned on left side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 6);
            }
            else
            {// spawned on right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(-5, -3);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }//while loop
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
