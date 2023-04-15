using System;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private Transform m_Transform; // Reference to the main camera's transform
    private Transform playerTransform; // Reference to the player's transform
    [SerializeField] private float distance = 10.0f; // The distance between the camera and the player
    private Vector3 offset; // The offset between the camera and the player

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
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
