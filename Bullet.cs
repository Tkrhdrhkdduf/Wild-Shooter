using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffect;
    public int dam = 50;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
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
    }




}
