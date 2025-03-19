using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform target;

    [Header ("Attributes")]
    
    public float range = 15f;
    public float firerate = 1f; //in Rounds per Minute
    public float fireCountdown = 0f;
    public GameObject bullet;
    public Transform firePoint;

    [Header ("Fields")]

    public string enemyTag;


    void Start()
    {
        InvokeRepeating("PickTarget", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        } else
        {
            transform.LookAt(target);
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 60f / firerate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void PickTarget()
    {
        Transform nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy.transform;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        
    }

    private void Shoot()
    {
        Debug.Log("Shoot!");
        GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bulletInstance.GetComponent<BulletScript>().Seek(target);
    }
}
