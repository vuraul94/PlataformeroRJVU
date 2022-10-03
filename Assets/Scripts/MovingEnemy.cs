using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    public float speed = 5f;

    public float direction = 1f;

    public float directionTimeChange = 4f;

    private Rigidbody2D rigidBody2D;

    private GameObject footR;

    private GameObject footL;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        // StartCoroutine(DirectionChange());
        footR = transform.Find("FootR").gameObject;
        footL = transform.Find("FootL").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(footR.transform.position, Vector2.down, Color.blue);
        Debug.DrawRay(footL.transform.position, Vector2.down, Color.blue);
        if (!Physics2D.Raycast(footR.transform.position, Vector2.down, 0.1f))
        {
            direction = -1;
            transform.localScale =
                new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        if (!Physics2D.Raycast(footL.transform.position, Vector2.down, 0.1f))
        {
            direction = 1;
            transform.localScale =
                new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(direction, rigidBody2D.velocity.y);
    }

    IEnumerator DirectionChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(directionTimeChange);
            direction = direction * -1;
            transform.localScale =
                new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
