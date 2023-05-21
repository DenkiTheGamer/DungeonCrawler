using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] spawnableObjects;
    private void Awake()
    {
        switch(Random.Range(0, 4))
        {
            case 0:
                Instantiate(spawnableObjects[0], transform);
                break;
            case 1:
                Instantiate(spawnableObjects[1], transform);
                break;
            case 2:
                Instantiate(spawnableObjects[2], transform);
                break;
            case 3:
                Instantiate(spawnableObjects[3], transform);
                break;
        }
    }
}
