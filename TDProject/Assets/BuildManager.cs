using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject magePrefab;
    public GameObject archerPrefab;
    private void Awake()
    {
        instance = this;
    }
    private GameObject turretToBuild;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
