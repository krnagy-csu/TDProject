using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Transform[] points;
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).transform;
            Debug.Log(points[i].name);
        }
    }
}
