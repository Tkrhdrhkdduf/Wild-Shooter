using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerpos;

    void Awake()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").transform; // object taged 를 사용해 찾음
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new  Vector3(playerpos.position.x, playerpos.position.y, transform.position.z); // 카메라 가 플레이어 따라다님
    }
}
