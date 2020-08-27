using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void LateUpdate() // after upadate and fixed update this output will run. Therefore, only update our mini map position 
        // 업뎃 메소드랑 픽스트 업뎃 메소드 후에 이 아웃풋이 실행됩니다. 그러므로 우리는 오직 미니맵 위치만 업데이트 됩니다
    {
        Vector3 playerposition = player.position;
        playerposition.y = transform.position.y; // y축 미니맵 플레이어포지션 위치를 바꿔줌
        transform.position = playerposition;  
        Vector3 playerposition1 = player.position;
        playerposition1.x = transform.position.x; // x축 미니맵 플레이어포지션1 위치를 바꿔줌
        transform.position = playerposition1;
    }
}
