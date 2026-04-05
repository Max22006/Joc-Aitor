using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Vector3 startPosition;

    private Transform cameraTarget;
    public Vector3 cameraOffset;
    
    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cameraTarget = GameObject.Find("Coco").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTarget != null)
       {
           Vector3 desiredPosition = cameraTarget.position + cameraOffset;

        float clampX = Mathf.Clamp(desiredPosition.x, minCameraPosition.x, maxCameraPosition.x);
        float clampY = Mathf.Clamp(desiredPosition.y, minCameraPosition.y, maxCameraPosition.y);

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        transform.position = clampedPosition; 
       }
    }
}
