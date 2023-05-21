using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public GameObject player;
    public int objectType;
    PlayerInventory inventory;    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            inventory = player.GetComponent<PlayerInventory>();
            Debug.Log(collision.gameObject.name + "collision");
            switch (objectType)
            {
                case 0:
                    inventory.weapons[0] = objectType;
                    break;
                case 1:
                    inventory.weapons[1] = objectType;
                    break;
                case 2:
                    inventory.weapons[2] = objectType;
                    break;
                case 3:
                    inventory.weapons[3] = objectType;
                    break;
                case 4:
                    inventory.weapons[4] = objectType;
                    break;
                case 5:
                    inventory.weapons[5] = objectType;
                    break;
                case 6:
                    inventory.weapons[6] = objectType;
                    break;
                case 7:
                    inventory.weapons[7] = objectType;
                    break;
            }
        }
    }
}