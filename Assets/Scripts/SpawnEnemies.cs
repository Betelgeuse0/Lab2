using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameObject mainCamera;
    private int maxEnemies = 20;
    private int enemyCount = 0;
    private IEnumerator cor;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        cor = SpawnEnemy(2);
        StartCoroutine(cor);
    }

    // Update is called once per frame
    void Update()
    {  
        //spawn enemies every 5 seconds until we've reached max
        
    }

    IEnumerator SpawnEnemy(float waitTime)
    {
        while (true)
        {
            if (enemyCount >= maxEnemies)
                continue;
            
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Vector3 camPos = mainCamera.transform.position;
        
            GameObject clone = Instantiate(enemy);
            clone.SetActive(true);
            
            float xPos = Random.Range(-20, 20);
            float zPos;
            if (Mathf.Abs(xPos) >= 10)
                zPos = Random.Range(-20, 20);
            else
                zPos = Random.Range(10, 20) * Mathf.Sign(Random.Range(-2, 1));

            clone.transform.position = camPos + new Vector3(xPos, -9, zPos);
            ++enemyCount;
            Debug.Log("Spawned Enemy");
            yield return new WaitForSeconds(waitTime);
        }
    }
}
