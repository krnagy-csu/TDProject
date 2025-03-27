using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float wayptError = 0.02f;
    public float speedFactor = 1f;
    public float baseSpeedFactor = 1f;

    [Header("Stats")]
    public float Health = 100;
    public int bounty = 50;

    [Header("Visuals")]
    public GameObject deathAnim;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += bounty;
        Instantiate(deathAnim, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
