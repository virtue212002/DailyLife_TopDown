using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public SpriteRenderer characterRender, weaponRender;
    public Vector2 pointerPosition { get; set; }

    private void Update()
    {
        Vector2 direction = (pointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }else if(direction.x > 0)
        {
            scale.x = 1;
        }
        transform.localScale = scale;

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180) { 
            
            weaponRender.sortingOrder = characterRender.sortingOrder -1;
        }
        else
        {
            weaponRender.sortingOrder = characterRender.sortingOrder +1;

        }
    }
}
