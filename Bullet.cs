﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffect;
    public int dam = 50;
    public int dam1 = 25;
    public int dam2 = 5;
    public int dam3 = 40;
    public int dam4 = 20;
    public int dam5 = 5;
    public int dam6 = 3;
    public int bossdam = 20;
    private float bulletspeed = 20;
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
        aeselionazard aeselionazard = hitDam.GetComponent<aeselionazard>();
        if (aeselionazard != null)
        {
            aeselionazard.damagehp(dam2);
        }
        Destroy(gameObject);
        cactusMovements cactus = hitDam.GetComponent<cactusMovements>();
        if(cactus != null)
        {
            cactus.damagehp(dam3);
        }
        Destroy(gameObject);
        bullswitchmovements bullswitch = hitDam.GetComponent<bullswitchmovements>();
        if (bullswitch != null){
            bullswitch.damagehp(dam4);
        }
        Destroy(gameObject);
        Kaserinmovements kaserin = hitDam.GetComponent<Kaserinmovements>();
        if(kaserin != null)
        {
            kaserin.damagehp(dam5);
        }
        Destroy(gameObject);
        Geoshinmovement Geoshin = hitDam.GetComponent<Geoshinmovement>();
        if (Geoshin != null)
        {
           Geoshin.damagehp(dam6);
        }
        Destroy(gameObject);
        Boss boss = hitDam.GetComponent<Boss>();
        if (boss != null)
        {
            boss.damagehp(bossdam);
        }
        Destroy(gameObject);



    }




}
