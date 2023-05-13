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
    //public List<int> roomAmount;
    public int roomNumber = 0;
    public int xDungeon;    
    public int yDungeon;

    public int roomTypeX;
    public int roomTypeY;


    private void Start()
    {
        rooms = xDungeon * yDungeon;     
        //roomAmount.
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

    public void roomCheck()
    {
        if (roomNumber - 1 < 0 || roomNumber % xDungeon == 0)
        {
            Debug.LogWarning("x-1 fail");
        }
        else
        {
            Debug.LogWarning(roomAmount[roomNumber - 1] + "x-1");
            roomTypeX = roomAmount[roomNumber - 1];
        }
        if (roomNumber - xDungeon < 0)
        {
            Debug.LogWarning("y-1 fail");
        }
        else
        {
            Debug.LogWarning(roomAmount[roomNumber - xDungeon] + "y-1");
            roomTypeY = roomAmount[roomNumber - xDungeon];
        }
    }

    private void GenerateDungeon()
    {
        Debug.Log("roomNumber " + roomNumber);
        if (roomNumber != rooms)
        {
            Vector3 pos;
            pos = transformsSpawn[roomNumber].transform.position;

            roomCheck();        
            
            Debug.LogWarning(roomNumber + "roomNumber");

            switch (roomAmount[roomNumber] = Random.Range(0, 5))
            {
                case 0:
                    Instantiate(dungeonPieces[0], pos, rot);
                    roomNumber++;
                    break;
                case 1:
                    Instantiate(dungeonPieces[1], pos, rot);
                    roomNumber++;
                    break;
                case 2:
                    Instantiate(dungeonPieces[2], pos, rot);
                    roomNumber++;
                    break;
                case 3:                   
                    Instantiate(dungeonPieces[3], pos, rot);
                    roomNumber++;              
                    break;
                case 4:
                    Instantiate(dungeonPieces[4], pos, rot);
                    roomNumber++;
                    break;
            }           
        }
    }
}
