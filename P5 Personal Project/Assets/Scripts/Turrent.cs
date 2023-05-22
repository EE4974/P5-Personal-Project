using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    private Transform target;
    public bool hasPowerUp;

    [Header("Attributes")]
    public float range = 15;
    public static float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemeyTag = "Enemy";

    public GameObject fireballPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemeyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else 
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
       
        fireCountdown -= Time.deltaTime;
    }

    void Shoot ()
    {
        GameObject fireballGo = (GameObject)Instantiate (fireballPrefab, firePoint.position, firePoint.rotation);
        Fireball fireball = fireballGo.GetComponent<Fireball>();
        if (fireball != null)
            fireball.Seek(target);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
           Pickup();
           StartCoroutine(PowerupCountdownRoutine());
        }
    }

    void Pickup()
    {
    hasPowerUp  = true;
    Destroy(GameObject.FindWithTag("Powerup"));
    Debug.Log ("E");
    fireRate = 5;
    range = 20;
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;
    }
}
