using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        if (PlayerMovement.isPaused)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + player.position.z + 23f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 10f);
        }
    }
}