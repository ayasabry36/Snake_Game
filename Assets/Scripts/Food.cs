using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject foodPrefab;
    public int foodCount = 10;
    public float width = 80f;
    public float height = 60f;

    void Start()
    {
        SpawnFood();
    }

    void SpawnFood()
    {
        for (int i = 0; i < foodCount; i++)
        {
            float x = Random.Range(-width / 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);
            float z = -7f;

            Vector3 spawnPosition = new Vector3(x, y, z);

            Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
