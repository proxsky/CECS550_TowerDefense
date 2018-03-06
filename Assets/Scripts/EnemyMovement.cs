using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 20f; //Movement Speed

    private Transform nextWaypoint; //Coordinates of wayPoint
    private int wavepointIndex = 0; //Track wavepoints
        	
	void Start ()
    {
        //Set the coordinate to the first wayPoint;
        nextWaypoint = Waypoints.wayPoints[wavepointIndex];	
	}	
	
	void Update ()
    {
        //Get the direction from enemy to the waypoint.
        Vector3 direction = nextWaypoint.position - transform.position;

        //This moves the enemey towards the waypoint.
        // Normalized direction vector to keep the same direction and set length to 1. 
        //deltaTime make sures that the speed isn't dependent on FPS.
        //Make the space relative to world space.
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        
        //Check to see if enemey has reached waypoint. 
        //If yes, call method to get next waypoint.
        if (Vector3.Distance(transform.position, nextWaypoint.position) <= 0.2f)
            GetNextWayPoint();
	}

    /// <summary>
    /// Get the next waypoint. If enemy reached last waypoint, destory itself.
    /// If not, get next waypoint.
    /// </summary>
    private void GetNextWayPoint()
    {        
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            Tracker.lives--;
          
        }
        else
        {
            wavepointIndex++;
            nextWaypoint = Waypoints.wayPoints[wavepointIndex];
        }
    }

    private void OnDestroy()
    {
        Tracker.money += 1;
    }
}
