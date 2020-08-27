using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponchange : MonoBehaviour
{
    public Weapon wp;
    private void OnTriggerEnter2D(Collider2D witem)
    {
        if (witem.tag == "Player")
        {
            witem.GetComponent<PlayerMovements>().currentw = wp;
            witem.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = wp.currentsprite; // 4번쨰 자식 피스트롤을 현재 아이템에게 충돌했을떄 스프라이트 변경
            Destroy(gameObject);
        }
    }
}
