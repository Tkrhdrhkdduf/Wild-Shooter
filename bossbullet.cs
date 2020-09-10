using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 firetg;
    public int dam = 25;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        firetg = new Vector2(player.position.x, player.position.y);// 파이어라는 오브젝트가 스폰되면 플레이어 위취를 바라봄
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, firetg, speed * Time.deltaTime);// 이것은 첨 본 플레이어 위치를 보고 앞으로 날라감
        if (transform.position.x == firetg.x && transform.position.y == firetg.y)// x축과 y축이 동일하면 
        {
            firetghit();
        }
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        PlayerMovements player = hit.GetComponent<PlayerMovements>();
        if (player != null)
        {
            player.playerdamhp(dam);
        }
        if (hit.tag == "Player")
        {
            firetghit();
        }

    }
    void firetghit()
    {
        Destroy(gameObject);
    }
}
