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

        int rotationIndex = Random.Range(0, 4);
        int rotation = 0;
        switch (rotationIndex)
        {
            case 0:
                rotation = 0; break;
            case 1:
                rotation = 90; break;
            case 2:
                rotation = 180; break;
            case 3:
                rotation = -90; break;
            default:
                break;

        }
        _room.transform.rotation = Quaternion.Euler(0,rotation,0);
        gameObject.SetActive(false);
    }
}
