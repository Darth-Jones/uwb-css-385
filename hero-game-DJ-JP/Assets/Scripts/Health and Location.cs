using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndLocation : MonoBehaviour
{
    public float maxHP;
    private float currentHP;
    private float opacity;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        opacity = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void updateHealth()
    {

        currentHP--;

        if (currentHP == 0)
        {
            if (tag.Contains("nemy"))
            {
                Destroy(gameObject);
            }
            else
            {
                changeLocation();
            }
        }
        else
        {
            opacity -= (1.0f / maxHP);
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, opacity);
        }
        // apply the fade witht he alpha channel thingy

            
        

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
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        opacity = 1f;
        sprite.color = new Color(1f, 1f, 1f, opacity);
        currentHP = maxHP;
    }
}
