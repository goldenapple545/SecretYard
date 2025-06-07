using UnityEngine;

public class FollowCameraLookDirection : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float distanceFromCamera = 2f;

    private Transform _userCamera;

    void Start()
    {
        _userCamera = Camera.main.transform;
    }

    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 cameraForward = _userCamera.forward;
        
        Vector3 targetPosition = _userCamera.position + cameraForward * distanceFromCamera;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}