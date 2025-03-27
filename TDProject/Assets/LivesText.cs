using UnityEngine;
using TMPro;
public class LivesText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshPro>().text = "Lives: " + PlayerStats.Lives.ToString("00");
    }
}
