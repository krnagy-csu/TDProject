using UnityEngine;
using TMPro;
public class NodeUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Node targetNode;
    public GameObject canvas;
    public TextMeshProUGUI upgradeCost;
    public void SetTarget (Node tgt)
    {
        canvas.SetActive(true);
        upgradeCost.text = "<b>UPGRADE:</b> " + tgt.turretBlueprint.upgradeCost;
        targetNode = tgt;
        transform.position = targetNode.transform.position;
    }

    public void Hide()
    {
        canvas.SetActive(false);
    }

    public void Upgrade()
    {
        targetNode.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
