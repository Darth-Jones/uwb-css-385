using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthandLocation : MonoBehaviour
{
   // public int maxHP;
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = 4;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void updateHealth()
    {
        if (tag.Contains("nemy"))
        {
            Destroy(gameObject);
        }
        else
        {
            currentHP--;
            
            // apply the fade witht he alpha channel thingy

            if (currentHP == 0)
            {
                changeLocation();
            }
        }

    }
    void changeLocation()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        if (Random.Range(0, 2) == 0)
        {
            xPos += 15;
        }
        else
        {
            xPos -= 15;
        }

        if (Random.Range(0, 2) == 0)
        {
            yPos += 15;
        }
        else
        {
            yPos -= 15;
        }
        // need to make sure they are still in bounds


        Vector2 newPosition = new Vector2(xPos, yPos);
        transform.position = newPosition;
    }
}
