using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyPrefabs;

    [SerializeField]
    private float speedInterval, maxWaitTime, betweenWaves;




    private int wave;



    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        maxWaitTime = maxWaitTime - speedInterval;
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            System.Random rand = new System.Random(); // random kterej asi nepouzivam idk
            
            if(wave % 5 == 0){ // kazdou 5 wave spawni bose dikyyy
                
                SpawnBoss();
                Debug.Log("Spawnovani Boseeee");
            }
            else{
                for(int i = 0; i < (int)(Math.Pow(wave,1.3)); i++){ // wave^1.3 enemaku
                    yield return new WaitForSeconds(speedInterval + rand.Next(0,(int)(maxWaitTime)));
                    SpawnEnemy();
                }
                
            }
            Debug.Log(wave);
            wave += 1;
            yield return new WaitForSeconds(betweenWaves); // Grace period mezi wavekama

        }
    }

    private void SpawnBoss(){
        GameObject Prefab = enemyPrefabs[enemyPrefabs.Count-1]; // Boss Index musi byt posledni
        Instantiate(Prefab, transform.position, Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        GameObject randomPrefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count-1)]; // bez boss indexu
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }
}
