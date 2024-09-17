using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Unity.VisualScripting.StickyNote;

public class FloorMerger : MonoBehaviour
{
    [SerializeField] GameObject floorParent;
    [SerializeField] Transform[] Checkers;
    [SerializeField] LayerMask layerMask;

    RoomDirector roomDirector;

    private void Start()
    {
        roomDirector = GameObject.FindObjectOfType<RoomDirector>();

        if (Checkers.Length == 0) return;
        for (int i = 0; i < Checkers.Length; i++)
        {
            GameObject FloorOverlaped = CheckForRooms(Checkers[i].position);
            Debug.Log(FloorOverlaped);
            if (FloorOverlaped != null) Debug.Log("Floor Overlaping");
            floorParent.SetActive(true);
        }
    }

    private GameObject CheckForRooms(Vector3 CoordsToCheck)
    {
        CoordsToCheck -= transform.position;
        Ray ray = new Ray(transform.position, CoordsToCheck);
        RaycastHit hit;
        Debug.Log($"{Physics.Raycast(ray, out hit, float.MaxValue)}: {gameObject.name}");
        Debug.Log(ray);
        Debug.DrawRay(ray.origin, ray.direction * float.MaxValue, Color.magenta, 60);
        if (Physics.Raycast(ray, out hit, float.MaxValue,layerMask))
        {
            Debug.Log($"FloorCollision: {gameObject.name}");
            return hit.collider.gameObject;
        }
        else return null;
        
    }


    private void ReRollRoom()
    {
        int roomNumber = Random.Range(1, roomDirector.Rooms.Length - 1);
        GameObject _room = GameObject.Instantiate(roomDirector.Rooms[roomNumber]);
        _room.transform.position = transform.position;
        Destroy(gameObject);
    }
}
