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
        playerposition.y = transform.position.y;
        transform.position = playerposition;
        Vector3 playerposition1 = player.position;
        playerposition1.x = transform.position.x;
        transform.position = playerposition1;
    }
}
