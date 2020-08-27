using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffect;
    public int dam = 50;
    public int dam1 = 25;
    private float bulletspeed = 13;
    private Vector2 Direction;
    void Start()
    {
        Direction = GameObject.Find("Direction").transform.position;  // 게임오브젝트 direction 트랜스폼 포지션 값
        transform.position = GameObject.Find("fire point").transform.position;// 게임오브젝트 firepoint 트랜스폼 포지션 값
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Direction, bulletspeed * Time.deltaTime); // 불렛 위치랑 불렛 속도 만큼 위치 변경
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); // 충돌하면 회전위치 그대로 게임오브젝트 실행
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D hitDam)
    {
        enemymovements enemy=hitDam.GetComponent<enemymovements>();
        if(enemy !=null)
        {
            enemy.damagehp(dam);
        }
        Destroy(gameObject);
        Leopiodmovements leopiod = hitDam.GetComponent<Leopiodmovements>();
        if (leopiod != null)
        {
            leopiod.damagehp(dam1);
        }
        Destroy(gameObject);


    }




}
