using UnityEngine;

namespace Model
{
    public class RotatorByInput : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10f;

        private const string MOUSE_X = "Mouse X";
        private const string MOUSE_Y = "Mouse Y";

        private void Update()
        {
            if (Input.GetMouseButton(1)) 
                Rotate();
        }
        private void Rotate()
        {
            float horizontalRotation = Input.GetAxis(MOUSE_X) * rotationSpeed;
            float verticalRotation = Input.GetAxis(MOUSE_Y) * rotationSpeed;

            transform.Rotate(Vector3.up, -horizontalRotation, Space.World);
            transform.Rotate(Vector3.right, verticalRotation, Space.World);
        }
    }
}