using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    [SerializeField] RoomDirector roomDirector;

    void Start()
    {
        roomDirector = GameObject.FindObjectOfType<RoomDirector>();

        GameObject _room;

        if(transform.position == roomDirector.RoomsPositions[0])
        {
            _room = GameObject.Instantiate(roomDirector.Rooms[0]);
        }

        else if (transform.position == roomDirector.RoomsPositions[roomDirector.RoomsPositions.Count-1])
        {
            _room = GameObject.Instantiate(roomDirector.Rooms[roomDirector.Rooms.Length-1]);
        }

        else
        {
            int roomNumber = Random.Range(1, roomDirector.Rooms.Length-1);
            _room = GameObject.Instantiate(roomDirector.Rooms[roomNumber]);
        }

        _room.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
