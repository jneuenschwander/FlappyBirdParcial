using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnaPool : MonoBehaviour
{

    [SerializeField] public int columnPoolSize = 5;
    private GameObject[] columns;
    public GameObject columnPrefab;
    public Vector2 objectPoolPosition = new Vector2(-20, 0);
    private float timeSinceLastSpawned;
    public float spawnRate;
    public float columnMax = 3f;
    public float columnMin = 11.52f;
    public float spawnXposition = 20f;
    private int currentColumn;
    void Start()
    { 
        timeSinceLastSpawned = 0f;
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        { 
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition,Quaternion.identity);
            
        }
    }

    
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        
        if (GameController.instance.GameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            
            timeSinceLastSpawned = 0;
            
            float spawnYposition = Random.Range(columnMin, columnMax);
            
            columns[currentColumn].transform.position = new Vector2(spawnXposition, spawnYposition);
            
            currentColumn++; 
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
                
            }
        }
    }
}
