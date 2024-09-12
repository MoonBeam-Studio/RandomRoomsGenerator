using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMerger : MonoBehaviour
{
    [SerializeField] GameObject floorParent;
    [SerializeField] Transform[] Checkers;
    [SerializeField] RoomDirector roomDirector;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        roomDirector = GameObject.FindObjectOfType<RoomDirector>();

        for (int i = 0; i < Checkers.Length; i++)
        {
            GameObject FloorOverlaped = CheckForRooms(Checkers[i].position);
            if (FloorOverlaped == null) return;
            if (FloorOverlaped.name == roomDirector.Rooms[0].name || FloorOverlaped.name == roomDirector.Rooms[roomDirector.Rooms.Length-1].name) Debug.Log("Floor Overlaping");
            floorParent.SetActive(true);
        }
    }

    private GameObject CheckForRooms(Vector3 CoordsToCheck)
    {
        Ray ray = new Ray(CoordsToCheck, new Vector3(CoordsToCheck.x, -1, CoordsToCheck.z));
        RaycastHit hit;
        //Debug.Log($"{Physics.Raycast(ray, out hit, float.MaxValue)}: {gameObject.name}");
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log($"FloorCollision: {gameObject.name}");
            return hit.collider.gameObject;
        }
        else return null;
        
    }
}
