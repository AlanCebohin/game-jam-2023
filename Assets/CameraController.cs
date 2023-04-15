using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform m_Transform;
    private Transform playerTransform;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        m_Transform.position = new Vector3(0, m_Transform.position.y, playerTransform.position.z);
    }
}
