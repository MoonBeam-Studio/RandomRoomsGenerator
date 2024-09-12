using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverlapingRoom : MonoBehaviour
{
    private void Update()
    {
        Ray ray = new Ray(transform.position, new Vector3(transform.position.x, -1, transform.position.z));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Room Overlaping");
            Destroy(gameObject);
        }
    }
}