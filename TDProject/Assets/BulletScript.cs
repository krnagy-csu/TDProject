using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 20f;
    public int damage = 10;
    private bool hit = false;
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
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void bulletRemove()
    {
        transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Stop();
        Destroy(gameObject, 0.5f);
    }

    void HitTarget()
    {
        if (!hit) { 
        Debug.Log("HIT!");
        bulletRemove();
        }
        hit = true;
    }
}
