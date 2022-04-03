using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private float direction;

    Enemy mouse;

    void Start()
    {
        direction = -1;
        mouse = new Enemy(gameObject, 3.5f);
        mouse.Move(direction);
    }

    void Update()
    {
        mouse.Move(direction);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Wall"))
        {
            if (direction > 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
    }
}
