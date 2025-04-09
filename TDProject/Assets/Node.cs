using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material untargeted;
    public Material hovered;
    private GameObject turret;
    public GameObject[] turretPrefabs;

    BuildManager buildManager;

    MeshRenderer myRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material = untargeted;

        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        myRenderer.material = hovered;

    }

    private void OnMouseExit()
    {
        myRenderer.material = untargeted;
    }

    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Can't build there!");
        }
        else
        {
            turret = Instantiate(BuildManager.instance.GetTurretToBuild(), transform.position+(transform.up*0.5f), Quaternion.identity);
        }
    }
}
