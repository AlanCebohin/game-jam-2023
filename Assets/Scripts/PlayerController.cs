using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Transform m_Transform;
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 100.0f;
    private float rotationAngle = 0.0f;
    private float motionDirection = 0.0f;

    private bool _isMoving;

    public bool IsMoving { get => _isMoving; set => _isMoving = value; }

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
    void Update()
    {
        GetInput();
        UpdatePosition();
    }
    private void GetInput()
    {
        rotationAngle = (Input.GetAxis("Horizontal") * rotationSpeed) * Time.deltaTime;
        motionDirection = (Input.GetAxis("Vertical") * movementSpeed) * Time.deltaTime;
    }
    private void UpdatePosition()
    {
        if (_isMoving == true)
        {
            Move(motionDirection);
            Rotate(rotationAngle);
        }
    }
    private void Move(float motionDirection)
    {
        m_Transform.Translate(Vector3.forward * motionDirection);
    }
    private void Rotate(float rotationAngle)
    {
        m_Transform.Rotate(0, rotationAngle, 0.0f, Space.Self);
    }
}