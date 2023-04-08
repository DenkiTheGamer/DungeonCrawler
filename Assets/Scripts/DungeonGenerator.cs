using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public GameObject[] dungeonPieces;
    public GameObject generator;

    public Vector2 spawnPoints;
    public Quaternion rot;
    public Transform[] transformsSpawn;

    public int rooms;
    public int[] roomAmount;
    public int roomNumber = 0;
    public int xDungeon;    
    public int yDungeon;   


    private void Start()
    {
        rooms = xDungeon * yDungeon;     
        Generate();
    }   
    private void Generate()
    {
        int x = 0;
        spawnPoints.x = 0;
        spawnPoints.y = 0;
       
        for (int i = 0; i < yDungeon; i++)
        {
            spawnPoints.y += 8;
            for (int j = 0; j < xDungeon; j++)
            {               
                Debug.Log("x " + x);
                spawnPoints.x += 8;
                generator.transform.position = spawnPoints;
                Debug.Log(generator.transform.position);
                transformsSpawn[x] = generator.transform;
                GenerateDungeon();
                Debug.Log("x " + x);
                x++;
                            
            }
            spawnPoints.x = 0;
           
        }
    }
    private void GenerateDungeon()
    {
        Debug.Log("roomNumber " + roomNumber);
        if (roomNumber != rooms)
        {
            Vector3 pos;
            pos = transformsSpawn[roomNumber].transform.position;
                   
            switch (roomAmount[roomNumber] = Random.Range(0, 5))
            {
                case 0:
                    Instantiate(dungeonPieces[0], pos, rot);
                    break;
                case 1:
                    Instantiate(dungeonPieces[1], pos, rot);
                    break;
                case 2:
                    Instantiate(dungeonPieces[2], pos, rot);
                    break;
                case 3:
                    Instantiate(dungeonPieces[3], pos, rot);
                    break;
                case 4:
                    Instantiate(dungeonPieces[4], pos, rot);
                    break;
            }

            roomNumber++;
        }
    }
}
