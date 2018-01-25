using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float range = 10f; //Turret attack range
    public Transform partToRotate; //The head of the turret

    private Transform target; //Coordinates of target
  
    /// <summary>
    /// Call UpdateTarget Method every 2 seconds
    /// to check for new target.
    /// </summary>
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    /// <summary>
    /// If there is no target, do nothing.
    /// If yes, rotate turret to point at direction of target.
    /// </summary>
    private void Update()
    {
        if (target == null)
            return;
        else
        {
            //Get the direction of target by 
            //subtracting turret position from target position
            Vector3 direction = target.position - transform.position;

            //Get look rotation using direction vector
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            //Store lookRation in a Vector3 so only rotate Y, and not X,Z. Lerp helps
            //smooth the rotating animation.
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*10).eulerAngles;

            //Rotate only Y
            partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);


        }
    }

    /// <summary>
    /// Find the nearest enemy.
    /// </summary>
    private void UpdateTarget()
    {
        //Get all enemies and store them in enemies array.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity; 
        GameObject nearestEnemy = null;

        //Loop through all enemies and find the nearest enemy.
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //If there is a nearest enemy and the distance
        //is within the range, sent the enemy as target.
        if(nearestEnemy!=null&&shortestDistance<range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    /// <summary>
    /// Show turrent range when selected. 
    /// Doesn't show ingame, only in editor.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position,range);
    }

}
