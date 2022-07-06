using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] public int currentIndex = 0;

    [SerializeField] public float moveSpeed = 2f;

    void Update()
    {   
        // check if the distance to the waypoint is close
        if(Vector3.Distance(transform.position, wayPoints[currentIndex].transform.position) < 0.1f){
            currentIndex++;
            if(currentIndex >= wayPoints.Length){
                currentIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentIndex].transform.position, moveSpeed * Time.deltaTime);
    }

}
