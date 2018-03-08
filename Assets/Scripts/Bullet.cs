using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target; //Bullet target

    public GameObject effect; //Impact Effect

    public void Chase(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        //If for some reason target is null, destory the bullet
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;//Direction of target
        float distanceThisFrame = 50 * Time.deltaTime; //How far the bullet travels per frame.

        //Means bullet has reach target, prevent over shoot.
        if(direction.magnitude<=distanceThisFrame) 
        {
            HitTarget();
            return;
        }

        //Move the bullet towards target
        transform.Translate(direction.normalized * distanceThisFrame,Space.World);

    }

    /// <summary>
    /// When bullet hits target, create impact effect then destory the effect and bullet.
    /// </summary>
    private void HitTarget()
    {
        GameObject temp = Instantiate(effect, transform.position, transform.rotation);
        Destroy(temp,2f);

        //Destroy(target.gameObject);
        target.GetComponent<EnemyMovement>().Damage(10);

        Destroy(gameObject);

    }


}
