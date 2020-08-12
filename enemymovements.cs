using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovements : MonoBehaviour
 
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // 이컴포넌트는 RB를 이용하여 우리의 물체의 움직임과 회전을 조작할수있음
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;// 매인 캐릭터와 적에 거리를 알기 위해서
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 플레이어와 적에 보는 시선 각도를 만듬, 우리의 물체를 우리 선수 방향으로 회전시키고
        //atan2는 기본적으로 0과 벡터 대 점 사이의 각도를 계산한다.그것은 우리의 적 대상과 선수 사이의 각도를 계산하는 것을 의미한다.
        rb.rotation = angle; // rb 각도가 회전할떄마다
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }
    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
