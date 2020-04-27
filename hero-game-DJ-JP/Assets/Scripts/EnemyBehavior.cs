using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float mSpeed = 5f;
	public float turnSpeed = 10f;
	private Rigidbody2D rb2d;
    private float turnTime;
	private float startTime;
	private bool wandering = false;
	private float coinFlip;

	// Use this for initialization
	void Start () {
	    Debug.Log("Enemy start");
	    rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMotion();
	}

    //moves the gameObject and calls the wander function
	private void UpdateMotion()
	{
        rb2d.MovePosition(rb2d.position + (Vector2)(transform.TransformDirection(Vector3.up) * mSpeed) * Time.deltaTime);
        Wander();
	}

    //Refects over the Z-axis when the gameObject collides with a wall.
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision");
		if (collision.gameObject.name.Contains("Wall"))
		{
			transform.up = Vector2.Reflect(transform.up, collision.GetContact(0).normal);
			
		}
	}

    //Uses the Random Range to make the enemy wander the screen
	private void Wander()
    {

        if (!wandering)
        {
			startTime = Time.time;
			turnTime = Random.Range(1f, 8f);
            coinFlip = Random.Range(0, 2);
		}

		if (Time.time <= startTime + turnTime)
		{	
			if (coinFlip == 0)
				rb2d.MoveRotation(rb2d.rotation + turnSpeed * Time.deltaTime);
			if (coinFlip == 1)
				rb2d.MoveRotation(rb2d.rotation - turnSpeed * Time.deltaTime);
			wandering = true;
		}
		else
			wandering = false;
        
    }
}
