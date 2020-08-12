using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    private Vector2 move;
    private Animator leganime;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        leganime = transform.GetChild(2).GetComponent<Animator>(); // 3번쨰 자식 애니메이션 가지고옴
    }
    private void Update()
    {
        Rotation();
    }



    // Update is called once per frame



    void FixedUpdate()
    {
        Movements();

    }
    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }
    void Movements()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = moveinput.normalized * speed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
        if (move == Vector2.zero)// leg anime 가 고정
            leganime.SetBool("move1", false);
        else
            leganime.SetBool("move1", true);// leg anime 발동 

        
    }
}
