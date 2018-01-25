using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    //Static so other classes can easily access the array.   
    public static Transform[] wayPoints; //Hold wayPoint coordinates

    private void Awake()
    {
        //Initialize wayPoints array and check size equal to number of wayPoints.
        wayPoints = new Transform[transform.childCount];

        //Get all child wayPoints and store in wayPoints array.
        for (int i = 0; i < wayPoints.Length; i++)
            wayPoints[i] = transform.GetChild(i);

    }

}
