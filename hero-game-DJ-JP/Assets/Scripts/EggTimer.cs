using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTimer : MonoBehaviour
{
    public float eggExperation = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroies the egg after one second
        Destroy(gameObject, eggExperation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            //Destroies the egg on collision with walls
            Destroy(gameObject);
        }
    }
}
