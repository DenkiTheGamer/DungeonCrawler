using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
                //Debug.Log("x " + x);
                spawnPoints.x += 8;
                generator.transform.position = spawnPoints;
                //Debug.Log(generator.transform.position);
                transformsSpawn[x] = generator.transform;
                GenerateDungeon();
                //Debug.Log("x " + x);
                x++;
                            
            }
            spawnPoints.x = 0;
           
        }
    }

    public void roomCheck()
    {
        if (roomNumber - 1 < 0 || roomNumber % xDungeon == 0)
        {
            //Debug.LogWarning("x-1 fail");
        }
        else
        {
            //Debug.LogWarning(roomAmount[roomNumber - 1] + "x-1");
            roomTypeX = roomAmount[roomNumber - 1];
        }
        if (roomNumber - xDungeon < 0)
        {
            //Debug.LogWarning("y-1 fail");
        }
        else
        {
            //Debug.LogWarning(roomAmount[roomNumber - xDungeon] + "y-1");
            roomTypeY = roomAmount[roomNumber - xDungeon];
        }
    }

    private void GenerateDungeon()
    {
        //Debug.Log("roomNumber " + roomNumber);
        if (roomNumber != rooms)
        {
            Vector3 pos;
            pos = transformsSpawn[roomNumber].transform.position;

            roomCheck();        
            
            //Debug.LogWarning(roomNumber + "roomNumber");

            switch (roomAmount[roomNumber] = Random.Range(0, 6))
            {
                case 0:
                    if (roomTypeX == 4 || roomTypeX == 5 || roomTypeY == 1 || roomTypeY == 2)
                    {                     
                        GenerateDungeon();
                        //Debug.LogError("RoomType 0 fail RoomType 4 or 5 x-1");
                    }
                    else
                    {
                        Instantiate(dungeonPieces[0], pos, rot);
                        roomNumber++;
                    }
                    break;
                case 1:
                    if (roomTypeX == 5 || roomTypeX == 4 || roomTypeY == 0 || roomTypeY == 3 || roomTypeY == 4 || roomTypeY == 5)
                    {
                        GenerateDungeon();
                        //Debug.LogError("RoomType 1 fail RoomType 4 or 5 x-1");
                    }
                    else
                    {
                        Instantiate(dungeonPieces[1], pos, rot);
                        roomNumber++;
                    }
                    break;
                case 2:
                    if (roomTypeX == 4 || roomTypeX == 5 || roomTypeY == 1 || roomTypeY == 2)
                    {
                        GenerateDungeon();
                        //Debug.LogError("RoomType 2 fail RoomType 4 or 5 x-1");
                    }
                    else
                    {
                        Instantiate(dungeonPieces[2], pos, rot);
                        roomNumber++;
                    }
                    break;
                case 3:
                    if (roomTypeX == 0 || roomTypeX == 1 || roomTypeX == 2 || roomTypeX == 3 || roomTypeY == 0 || roomTypeY == 3 || roomTypeY == 4 || roomTypeY == 5)
                    {
                        GenerateDungeon();
                        //Debug.LogError("RoomType 3 fail RoomType 0 or 1 or 2 or 3 x-1");
                    }
                    else
                    {
                        Instantiate(dungeonPieces[3], pos, rot);
                        roomNumber++;
                    }
                    break;
                case 4:
                    if (roomTypeX == 5 || roomTypeX == 4 || roomTypeY == 4 || roomTypeY == 3 || roomTypeY == 0 || roomTypeY == 5)
                    {
                        GenerateDungeon();
                        //Debug.LogError("RoomType 4 fail RoomType 4 or 5 x-1");
                    }
                    else
                    {
                        Instantiate(dungeonPieces[4], pos, rot);
                        roomNumber++;
                    }
                    break;
                case 5:
                    if (roomTypeX == 0 || roomTypeX == 1 || roomTypeX == 2 || roomTypeX == 3 || roomTypeY == 1 || roomTypeY == 2)
                    {
                        GenerateDungeon();
                        //Debug.LogError("RoomType 5 fail RoomType 0 or 1 or 2 or 3 x-1");
                    }
                    else
                    {
                        Instantiate(dungeonPieces[5], pos, rot);
                        roomNumber++;
                    }
                    break;
            }           
        }
    }
}
