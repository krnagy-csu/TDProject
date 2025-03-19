using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 10f;
    public float wayptError = 0.02f;
    private Transform target;
    private int waypointindex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 vecToTarget = (target.position - transform.position);
        Vector3 dirToTarget = vecToTarget.normalized;
        float distToTarget = vecToTarget.magnitude;
        transform.position += dirToTarget * (moveSpeed * Time.deltaTime);
        if (distToTarget < wayptError && waypointindex < (Waypoints.points.Length-1))
        {
            waypointindex++;
            target = Waypoints.points[waypointindex];
        } else if (distToTarget<wayptError && waypointindex >= (Waypoints.points.Length - 1))
        {
            Destroy(gameObject);
        }
    }
}
