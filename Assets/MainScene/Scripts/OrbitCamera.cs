using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;

    private void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Цель для орбиты не установлена!");
            return;
        }

        if (Input.GetMouseButton(0))
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            float verticalInput = Input.GetAxis("Mouse Y");
            
            Orbit(target, horizontalInput, verticalInput);
        }
    }

    void Orbit(Transform target, float horizontal, float vertical)
    {
        target.Rotate(Vector3.up, -horizontal * rotationSpeed, Space.World);
        target.Rotate(Vector3.left, -vertical * rotationSpeed, Space.World);
    }
}