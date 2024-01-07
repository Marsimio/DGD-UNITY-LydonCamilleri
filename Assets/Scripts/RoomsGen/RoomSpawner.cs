using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public char openingDirection;

    private RoomTemplates roomTemplates;
    private int rand;
    public bool spawn = false;
    Vector3 offset = new Vector3(-2, 2, 0);
    private void Start()
    {
        roomTemplates= GameObject.Find("GameManager").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (!spawn)
        {
            if (openingDirection == 'D') // Down Openings
            {
                rand = Random.Range(0, roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[rand], transform.position + offset, transform.rotation);
            }
            else if (openingDirection == 'U') // Up Openings
            {
                rand = Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[rand], transform.position + offset, transform.rotation);
            }
            else if (openingDirection == 'L') // Left Openings
            {
                rand = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[rand], transform.position + offset, transform.rotation);
            }
            else if (openingDirection == 'R') // Right Openings
            {
                rand = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[rand], transform.position + offset, transform.rotation);
            }
            spawn = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            var roomSpawner = other.GetComponent<RoomSpawner>();
            if (roomSpawner != null && roomSpawner.spawn == false && spawn == false)
            {
                Debug.Log("Wall Room Spawned");
                Instantiate(roomTemplates.closedRoom, transform.position + offset, transform.rotation);
                Destroy(gameObject);
            }
            spawn= true;
        }
    }
}
