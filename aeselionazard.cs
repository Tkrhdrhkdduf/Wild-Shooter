using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aeselionazard : MonoBehaviour
{
    public float mspeed;
    public float distancestop;
    public float moveback;
    private Transform player;
    public int hp = 100;
    public GameObject death;

    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // 이컴포넌트는 RB를 이용하여 우리의 물체의 움직임과 회전을 조작할수있음
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 캐릭터 위치 알아옴 
        
    }
    public void damagehp(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) > distancestop) //플레이어와 에스리온나자드 거리를 알수있는 조건문 따라서 정지된 디스탠스 보다 둘 사이에거리가 크면 에스리온나자드는 플레이어 쪽으로 움직임
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, mspeed * Time.deltaTime); // 다가옴 일정한속도로
        }
        else if (Vector2.Distance(transform.position, player.position) < distancestop && Vector2.Distance(transform.position, player.position) > moveback)// 반대로 이조건문은 멈춥니다
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < moveback)// 이조건문은 플레이어와 가까워지면 뒤로 빠지는 조건문
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -mspeed * Time.deltaTime); // 다가옴 일정한속도로 뒤로감
        }
        
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
        rb.MovePosition((Vector2)transform.position + (direction * mspeed * Time.deltaTime));
    }
}
  
 

