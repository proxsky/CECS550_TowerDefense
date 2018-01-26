using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float fireCountDown = 0f; //Count down for next shot
    private Transform target; //Coordinates of target

    [Header("Attributes")]
    public float range = 10f; //Turret attack range
    public float fireRate = 1f; //Turret attack speed

    [Header("Setup")]
    public Transform partToRotate; //The head of the turret
    public Transform firePoint; //Where is point is shooting from
    public GameObject bulletPrefab; //Bullet to use
   
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

        //Get the direction of target by 
        //subtracting turret position from target position
        Vector3 direction = target.position - transform.position;

        //Get look rotation using direction vector
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        //Store lookRation in a Vector3 so only rotate Y, and not X,Z. Lerp helps
        //smooth the rotating animation.
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;

        //Rotate only Y
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Check to see if fireCountDown is 0
        if(fireCountDown<=0f)
        {
            Shoot();
            
            //EX: If firerate is 2, shoot every (1/2) sec 
            //EX: If firerate is 4, shoot every (1/4) sec
            fireCountDown = 1f / fireRate;

        }

        //Count down for next shot
        fireCountDown -= Time.deltaTime;   

    }

    /// <summary>
    /// Create bullet, get the bulletScript on the bullet and call the Chase method.
    /// </summary>
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>(); //Get the script on the bullet object

        if (bulletScript != null)
            bulletScript.Chase(target);
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
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //If there is a nearest enemy and the distance
        //is within the range, sent the enemy as target.
        if (nearestEnemy != null && shortestDistance < range)
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
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
