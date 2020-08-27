using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovements : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed;
    private Vector2 move;
    private Animator leganime;
    public int hp = 100;
    public GameObject gameover;
    public hpbar hpbar;
    public Weapon currentw;
    private float otherfire = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        leganime = transform.GetChild(2).GetComponent<Animator>(); // 3번쨰 자식 애니메이션 가지고옴
        transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = currentw.currentsprite;
    }
    public void Start()
    {
        hpbar.maxhp(hp); // maxhp 는 int hp 가 100 으로 설정했으므로 100임
    }
    public void playerdamhp(int dam)
    {
        hp -= dam;
        hpbar.healthvalue(hp); // 헬스바 값이 hp만큼 이뜻은 데미지를 주면 깍임
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        Instantiate(gameover, transform.position, Quaternion.identity);// 게임시작시 게임오브젝트 바꿈// 플레이어가 죽으면 그위치에서 게임오브젝트 바꿈
        Destroy(gameObject);
        SceneManager.LoadScene("gameover");

    }
    
    private void Update()
    {
        Rotation();
        if(Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= otherfire)
            {
                currentw.Shoot();
                otherfire = Time.time + 1 / currentw.firerate;
            }
        }
    }



    // Update is called once per frame



    void FixedUpdate()
    {
        Movements();

    }
    void Rotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // 카메라가 스크린 현재마우스 포지션 좌표를보고  위치를 바까줌
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90; // 현재 위치각도를 알기위해 +90은 시작시 위방향을 보기위해
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // z축회전
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime); // transform rotation 에서 rotation 회전하고 10*time.deltatime만큼 회전속도이다
    }
    void Movements()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = moveinput.normalized * speed; //무브 스피드가 균일한 속도로 이동
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
        if (move == Vector2.zero)// leg anime 가 고정
            leganime.SetBool("move1", false);
        else
            leganime.SetBool("move1", true);// leg anime 발동 

        
    }
}
