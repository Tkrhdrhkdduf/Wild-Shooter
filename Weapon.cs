using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentsprite;

    public GameObject bulletpreb;
    public float firerate = 1;
    public int damage = 20;
    
    public void Shoot()
    {
         Instantiate(bulletpreb, GameObject.Find("fire point").transform.position, Quaternion.identity);
    }
}
