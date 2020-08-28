using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireaeselioniazard : MonoBehaviour
{
    private float firebtw;
    public float sfirebtw;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        firebtw = sfirebtw;// 발사되는 시간에 간격이랑 시작 간격이랑 같다고 둠 첨엔
    }

    // Update is called once per frame
    void Update()
    {
        if (firebtw <= 0) // 0 이하면 발사 시간 간격을 줌 
        {
            Instantiate(fire, transform.position, Quaternion.identity);
            firebtw = sfirebtw;

        }
        else
        {
            firebtw -= Time.deltaTime; // 크면 간격 시간을 주림 에를 들어 A랑 B가 2초간격이었는데 B가 압찌르면 다시 B가 압지르지않게 시간을 줄여서 간격을 다시 주린다는것입니다
        }
    }
}
