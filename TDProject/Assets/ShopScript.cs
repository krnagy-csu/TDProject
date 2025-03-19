using UnityEngine;
 
public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PurchaseMage()
    {
        Debug.Log("Mage selected!");
        buildManager.SetTurretToBuild(buildManager.magePrefab);
    }
    public void PurchaseArcher()
    {
        Debug.Log("Archer selected!");
        buildManager.SetTurretToBuild(buildManager.archerPrefab);
    }
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
