using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraHandler2 : MonoBehaviour
{
    [Header("Target")]
    public Transform productObj;
    [Header("Zoom Limit")]
    public float zoomMin = 2f;
    public float zoomMax = 10f;
    [Header("Zoom Amount")]
    public float zoomStepSize = 0.2f;
    [Header("Rotation Speed")]
    public float rotationSpeed = 4f;
    [Header("Y Axis Angle Limit")]
    public float yMaxLimit = 75f;
    public float yMinLimit = -25f;
    [Header("Rotation Slowdown Rate")]
    public float smoothingRate = 2f;

    private float eulerAngleX = 70.0f;
    private float eulerAngleY = 0.0f;
    private float velocityX = 0.0f;
    private float velocityY = 0.0f;
    private float zoomDistance = 15.0f;

    private void Start()
    {
        // Initial rotation angles
        eulerAngleX = this.transform.eulerAngles.x;
        eulerAngleY = this.transform.eulerAngles.y;
    }

    private void Update()
    {
        if (!productObj)
            return;

        // Calculate zoom distance using mouse scroll
        zoomDistance += Input.mouseScrollDelta.y * zoomStepSize;

        // Limit the zoom in and out
        zoomDistance = Mathf.Clamp(zoomDistance, zoomMin, zoomMax);

        // Calculate rotation velocity with mouse drag
        if (Input.GetMouseButton(0))
        {
            velocityX += rotationSpeed * Input.GetAxis("Mouse X") / 100f;
            velocityY += rotationSpeed * Input.GetAxis("Mouse Y") / 100f;
        }

        // Calculate the rotation angles
        eulerAngleY += velocityX;
        eulerAngleX -= velocityY;

        // Decrease the rotation velocity smoothly
        velocityX = Mathf.Lerp(velocityX, 0, smoothingRate * Time.deltaTime);
        velocityY = Mathf.Lerp(velocityY, 0, smoothingRate * Time.deltaTime);

        // Limit the Euler angles within Y-Axis Limit
        eulerAngleX = Mathf.Clamp(eulerAngleX, yMinLimit, yMaxLimit);

        // Store the Euler angle values into Vector3
        Vector3 camEulerAngles = new Vector3(eulerAngleX, eulerAngleY, 0);

        // Assign new Euler angle values to the camera
        this.transform.eulerAngles = camEulerAngles;

        // Convert euler angles into a directional vector pointing towards camera
        Vector3 directionalVector = eulerToVector(camEulerAngles);

        // Calculate camera position in the orbit
        Vector3 camPosition = productObj.position + directionalVector * zoomDistance;

        // Assign new position to the camera
        this.transform.position = camPosition;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        angle += angle < -360f ? 360f : 0;
        angle -= angle > 360f ? 360f : 0;
        return Mathf.Clamp(angle, min, max);
    }

    private Vector3 eulerToVector(Vector3 eulerAngles)
    {
        float y = Mathf.Deg2Rad * eulerAngles.x;
        float x = Mathf.Deg2Rad * eulerAngles.y;

        var dirX = Mathf.Cos(y) * Mathf.Sin(x);
        var dirY = Mathf.Sin(y);
        var dirZ = Mathf.Cos(x) * Mathf.Cos(y);

        dirX *= -1;
        dirZ *= -1;

        return new Vector3(dirX, dirY, dirZ).normalized;
    }
}
