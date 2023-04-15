<<<<<<< HEAD
using System;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private Transform m_Transform; // Reference to the main camera's transform
    private Transform playerTransform; // Reference to the player's transform
    [SerializeField] private float distance = 10.0f; // The distance between the camera and the player
    private Vector3 offset; // The offset between the camera and the player
=======
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform m_Transform;
    private Transform playerTransform;

>>>>>>> 23ef007b5f0580962d79476eecf17a81d7932693
    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
<<<<<<< HEAD
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // Calculate the offset between the camera and the player
        offset = m_Transform.position - playerTransform.position;
    }
    void LateUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        // Move the camera to the player's position plus the offset
        m_Transform.position = playerTransform.position + offset;
        // Keep the camera at the same distance from the player
        m_Transform.position -= m_Transform.forward * distance;
    }
}
=======

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
>>>>>>> 23ef007b5f0580962d79476eecf17a81d7932693
