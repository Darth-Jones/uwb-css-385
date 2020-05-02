using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP;
    private float currentHP;
    private float opacity;
    private float xAnchor;
    private float yAnchor;

    public GameObject uiCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        xAnchor = transform.position.x;
        yAnchor = transform.position.y;
        opacity = 1f;
        uiCounter = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void updateHealth()
    {
        currentHP--;

        // apply the fade witht he alpha channel thingy

        if (currentHP == 0)
        {
            if (tag.Contains("nemy"))
            {
                uiCounter.GetComponent<UITracking>().PlaneKilledByEgg();
                Destroy(gameObject);
            }
            else
            {
                changeLocation();
            }
        }
        else
        {
            opacity -= (1f / maxHP);
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1f, 1f, 1f, opacity);
        }

    }
    void changeLocation()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;


        Vector2 newPosition;
        do
        {
            newPosition = GetNewLocation(xAnchor, yAnchor);
        }
        while (newPosition.x == xPos && newPosition.y == yPos);
        // need to make sure they are still in bounds

        transform.position = newPosition;
        currentHP = maxHP;

        opacity = 1f;
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, opacity);
    }

    private Vector2 GetNewLocation(float xPos, float yPos)
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

