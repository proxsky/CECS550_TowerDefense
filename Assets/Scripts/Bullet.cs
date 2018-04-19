using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target; //Bullet target
    public float radius = 0;
    public GameObject effect; //Impact Effect
    public int damage = 10;

    public int speed = 50;

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
        float distanceThisFrame = speed * Time.deltaTime; //How far the bullet travels per frame.

        //Means bullet has reach target, prevent over shoot.
        if(direction.magnitude<=distanceThisFrame) 
        {
            HitTarget();
            return;
        }

        //Move the bullet towards target
        transform.Translate(direction.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }

    /// <summary>
    /// When bullet hits target, create impact effect then destory the effect and bullet.
    /// </summary>
    private void HitTarget()
    {
        GameObject temp = Instantiate(effect, transform.position, transform.rotation);
        Destroy(temp,2f);

        //Destroy(target.gameObject);

        if(radius>0f)
        {
            Explode();
        }
        else
        {
            target.GetComponent<EnemyMovement>().Damage(damage);
        }
              

        Destroy(gameObject);

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag=="Enemy")
            {
                collider.GetComponent<EnemyMovement>().Damage(damage);
        
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
