using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            float xPos = Random.Range(camPos.x - 8, camPos.x + 8);
            clone.transform.position = camPos + new Vector3(xPos, -10, -6);
            ++enemyCount;
            Debug.Log("Spawned Enemy");
            yield return new WaitForSeconds(waitTime);
        }
    }
}
