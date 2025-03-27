using UnityEngine;
using TMPro;
public class MoneyUIThingy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshPro>().text = "$" + PlayerStats.Money.ToString();
    }
}
