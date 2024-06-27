using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject hold;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float sensitivity = 3f;
    [SerializeField] private float clampAngleMin = -80f;
    [SerializeField] private float clampAngleMax = 80f;
    [SerializeField] private float distance = 5f;

    private float _rotX;
    private float _rotY;

    private void Start()
    {
        hold.SetActive(true);
        Vector3 rot = transform.localRotation.eulerAngles;
        _rotY = rot.y;
        _rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _rotY += Input.GetAxis("Mouse X") * sensitivity;
        _rotX -= Input.GetAxis("Mouse Y") * sensitivity;
        _rotX = Mathf.Clamp(_rotX, clampAngleMin, clampAngleMax);

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0.0f);
        transform.position = ballTransform.position - (rotation * Vector3.forward * distance);
        transform.LookAt(ballTransform.position);
    }
}
