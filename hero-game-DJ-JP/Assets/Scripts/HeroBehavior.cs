using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    // public EggStatSystem mEggStat = null;
    private float mHeroSpeed = 20f;
    private const float kHeroRotateSpeed = 22f;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update () {
        UpdateMotion();
        ChangeSpeed();
        TurnDirection();

    }

    private void UpdateMotion() {
        rb2d.MovePosition(rb2d.position + (Vector2)(transform.TransformDirection(Vector3.up) * mHeroSpeed) * Time.deltaTime);
    }

    //Checks angle of attack and peforms a check on location to create bounce
    //effect
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if (col.gameObject.name.Contains("Wall"))
        {
            transform.up = Vector2.Reflect(transform.up, col.GetContact(0).normal);
        }
    }

    //Allows the player to hit the W,S, and P keys to change velocity
    private void ChangeSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            mHeroSpeed += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            mHeroSpeed -= 1;
        if (Input.GetKey(KeyCode.P))
            mHeroSpeed = 0;
    }

    //Allows the player to hit the A and D keys to change direction 
    private void TurnDirection()
    {
        if (Input.GetKey(KeyCode.A))
            rb2d.MoveRotation(rb2d.rotation + kHeroRotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) 
            rb2d.MoveRotation(rb2d.rotation - kHeroRotateSpeed * Time.deltaTime);
    }
}
