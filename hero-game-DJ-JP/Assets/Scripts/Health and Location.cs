using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndLocation : MonoBehaviour
{
    public float maxHP;
    private float currentHP;
    private float opacity;

    private float xAnchor;
    private float yAnchor; 


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        opacity = 1.0f;
        xAnchor = transform.position.x;
        yAnchor = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void updateHealth()
    {
        // decrement the hp
        currentHP--;

        // health is 0
        if (currentHP == 0)
        {
            // hit an enemy
            if (tag.Contains("nemy"))
            {
                // destroy and update counter
                Destroy(gameObject);
                GameObject.Find("UI").GetComponent<UITracking>().PlaneKilledByEgg();
            }
            // hit a waypoint
            else
            {
                changeLocation();
            }
        }
        // still alive lower opacity
        else
        {
            opacity -= (1.0f / maxHP);
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, opacity);
        } 
    }

    void changeLocation()
    {
        float xCurrentPos = transform.position.x;
        float yCurrentPos = transform.position.y;

        Vector2 newPosition;
        do
        {
            newPosition = ChangeCoord(xAnchor, yAnchor);
        }
        while (newPosition.x == transform.position.x && newPosition.y == transform.position.y);
        // need to make sure they are still in bounds

        transform.position = newPosition;
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        opacity = 1f;
        sprite.color = new Color(1f, 1f, 1f, opacity);
        currentHP = maxHP;
    }

    private Vector2 ChangeCoord(float xPos, float yPos)
    {
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
        return new Vector2(xPos, yPos);
    }
}
