using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDirector : MonoBehaviour
{
    [SerializeField] int MinNumberOfRooms, MaxNumberOfRooms;
    [SerializeField] int MinRoomSize;
    [SerializeField] public  GameObject[] Rooms;
    [SerializeField] GameObject RoomSpawner;
    [SerializeField] public List<Vector3> RoomsPositions;

    public int roomNumber;

    private Vector2 lastCoord = new Vector2(0,0);


    private void Start()
    {
        int numberOfRooms = Random.Range(MinNumberOfRooms, MaxNumberOfRooms+2);

        for (int i = 0; i < numberOfRooms; i++)
        {
            roomNumber = i;
            Debug.Log("Room Spawner Positioned");

            GameObject roomSpawnerPosition = GameObject.Instantiate(RoomSpawner);
            
            Vector2 RoomCoord2d = CoordinatesGetter(i);
            Vector3 Coordinates = new Vector3(RoomCoord2d.x, 1, RoomCoord2d.y);

            while (RoomsPositions.Contains(Coordinates))
            {
                RoomCoord2d = CoordinatesGetter(i);
                Coordinates = new Vector3(RoomCoord2d.x, 1, RoomCoord2d.y);
            }
            roomSpawnerPosition.transform.position = Coordinates;
            RoomsPositions.Add(roomSpawnerPosition.transform.position);
        }
    }

    private Vector2 CoordinatesGetter(int counter)
    {
        Vector2 coord = new Vector2(0,0);

        if (counter == 0) return coord;


        int negativeOrPositive = 0;
        while (negativeOrPositive == 0) negativeOrPositive = Random.Range(-1, 2);

        int xy = 5 * negativeOrPositive;

        if (Random.Range(0, 2) == 0) coord = new Vector2(xy, 0);
        else coord = new Vector2(0, xy);

        coord += lastCoord;

        if(CoordChecker(coord))
        {
            CoordinatesGetter(counter);
            //return coord = null;
        }

        lastCoord = coord;
        return coord;
    }

    private bool CoordChecker(Vector2 CoordsToCheck)
    {
        Ray ray = new Ray(transform.position, new Vector3(CoordsToCheck.x, 1, CoordsToCheck.y));
        RaycastHit hit;

        return Physics.Raycast(ray, out hit);
    }
}
