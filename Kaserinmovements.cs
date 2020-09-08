using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaserinmovements : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int hp = 100;
    public GameObject death;
    public int dam =55;
    void Start()
    {
        rb=this.GetComponent<Rigidbody2D>();
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
    public void OnTriggerEnter2D(Collider2D damp)
    {
        PlayerMovements player = damp.GetComponent<PlayerMovements>();
        if(player != null)
        {
            player.playerdamhp(dam);
        }
    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
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
