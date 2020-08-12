using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite playermain;
    public Sprite main;
    private SpriteRenderer render;

    // Start is called before the first frame update
   
    private void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();

       
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            changeweapnsprite();
        }
    }
    void changeweapnsprite()
    {
        if (render.sprite == playermain)
        {
            render.sprite = main;
        }
        else
        {
            render.sprite = playermain;
        }
    }
}