using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 4f;
    public float zoomSpeed = 0.2f;
    public float zoomMin = 0f;
    public float zoomMax = 50f;
    public float yMaxLimit = 75f;
    public float yMinLimit = -25f;
    public float smoothingRate = 2f;
    public float speed = 5f; // Add this variable for the simple lerp movement

    private float EulerAngleX = 70.0f;
    private float EulerAngleY = 0.0f;
    private float velocityX = 0.0f;
    private float velocityY = 0.0f;
    private float zoomDistance = 50.0f;
    private bool isFollowing = false;

    [SerializeField]
    void Start()
    {
        EulerAngleX = transform.eulerAngles.x;
        EulerAngleY = transform.eulerAngles.y;
        
        transform.position = new Vector3(1.5f, 2f, -50f); // Set the camera's initial position
        transform.eulerAngles = new Vector3(0f, 0f, 0f); // Set the camera's initial rotation
    }

    void LateUpdate()
    {

        //Mouse x position
        float mouseX = Input.mousePosition.x;

        //Mouse y position
        if (mouseX <= 430)
        {
            //condition verification
            return;
        }
        
       if (target == null || isFollowing)
        return;

    Debug.Log("Camera position: " + transform.position);
    Debug.Log("Camera rotation: " + transform.eulerAngles);
    Debug.Log("Target position: " + target.position);

    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    transform.LookAt(target);

        // The rest of the original camera movement calculations can be kept as is
        zoomDistance += Input.mouseScrollDelta.y * zoomSpeed;
        zoomDistance = Mathf.Clamp(zoomDistance, zoomMin, zoomMax);

        if (Input.GetMouseButton(0))
        {
            velocityX += rotationSpeed * Input.GetAxis("Mouse X") / 100f;
            velocityY += rotationSpeed * Input.GetAxis("Mouse Y") / 100f;
        }

        EulerAngleY += velocityX;
        EulerAngleX -= velocityY;

        velocityX = Mathf.Lerp(velocityX, 0, smoothingRate * Time.deltaTime);
        velocityY = Mathf.Lerp(velocityY, 0, smoothingRate * Time.deltaTime);

        EulerAngleX = ClampAngle(EulerAngleX, yMinLimit, yMaxLimit);

        Vector3 camEulerAngles = new Vector3(EulerAngleX, EulerAngleY, 0);
        transform.eulerAngles = camEulerAngles;

        Vector3 directionalVector = EulerToVector(camEulerAngles);
        Vector3 camPosition = target.position + directionalVector * zoomDistance;
        transform.position = camPosition;
    }

    float ClampAngle(float angle, float min, float max)
    {
        angle = (angle < -360f) ? angle + 360f : angle;
        angle = (angle > 360f) ? angle - 360f : angle;
        return Mathf.Clamp(angle, min, max);
    }

    Vector3 EulerToVector(Vector3 EulerAngles)
    {
        float y = Mathf.Deg2Rad * EulerAngles.x;
        float x = Mathf.Deg2Rad * EulerAngles.y;

        float dirX = Mathf.Cos(y) * Mathf.Sin(x);
        float dirY = Mathf.Sin(y);
        float dirZ = Mathf.Cos(x) * Mathf.Cos(y);

        return new Vector3(-dirX, dirY, -dirZ).normalized;
    }

    public void SetTarget(Transform newTarget)
    {
        Debug.Log("Setting camera target to: " + newTarget.name);
        target = newTarget;
    }

    public void SetFollowing(bool following)
    {
        isFollowing = following;
    }
}
