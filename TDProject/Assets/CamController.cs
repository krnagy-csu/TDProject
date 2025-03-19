using UnityEngine;

public class CamController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness;
    private bool doMovement = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3((45 + ((transform.position.y - 10) * 0.8f)), -90, 0);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (doMovement)
        {
            Vector3 movement = new Vector3(0, 0, 0);
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                if (transform.position.x > 5)
                {
                    movement.x -= panSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                if (transform.position.x < 70)
                {
                    movement.x += panSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                if (transform.position.z < 60)
                {
                    movement.z += panSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                if (transform.position.z > 0)
                {
                    movement.z -= panSpeed * Time.deltaTime;
                }
            }

            float zoomCommand = Input.GetAxis("Mouse ScrollWheel") * -1000 * Time.deltaTime;
            if (((transform.position.y + zoomCommand) < 60) && ((transform.position.y + zoomCommand) > 10))
            {
                movement.y = zoomCommand;
            }

            transform.position += movement;
        }

    }
}
