using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float speed;

    public Transform player;
    public Transform camera;

    Vector3 camOffsetFromPlayer;

    void Start()
    {
        camOffsetFromPlayer = player.position - camera.position;
    }

    void Update()
    {
        camera.position = Vector3.Lerp(camera.position, player.position - camOffsetFromPlayer, speed);
    }
}
