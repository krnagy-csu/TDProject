using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    [Header ("Stats")]
    public float speed = 20f;
    public int damage = 10;
    public float damageRadius = 0;
    private bool hit = false;
    private bool exploded = false;

    [Header("Effects/Sub-objects")]
    public GameObject impactEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            bulletRemove();
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void bulletRemove()
    {
        transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Stop();
        transform.GetChild(0).gameObject.SetActive(false);
        if (!exploded)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            exploded = true;
        }
        Destroy(gameObject, 0.5f);
    }

    void HitTarget()
    {
        if (!hit) { 
        Debug.Log("HIT!");
            bulletRemove();
            if (damageRadius > 0f)
            {
                Explode();
            }
            else
            {
                Damage(target);
            }
        }
        hit = true;
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);

    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
}
