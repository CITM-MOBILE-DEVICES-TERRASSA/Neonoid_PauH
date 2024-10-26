using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 velInicial;
    [SerializeField] private float multiVel;
    [SerializeField] private int pointsValue;
    [SerializeField] private ScoreScript totalScore;

    private Rigidbody2D ballRb;
    private bool isBallMoving;
    private AudioSource destroyBlock;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        destroyBlock = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            Launch();
        }
    }

    private void Launch()
    {
        transform.parent = null;
        ballRb.velocity = velInicial;
        isBallMoving = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            ballRb.velocity *= multiVel;
            GameManager.Instance.BlockDestroyed();
            totalScore.AddScore(pointsValue);
            destroyBlock.Play();
        }
        VelFix();
    }
    private void VelFix()
    {
        float velDelta = 0.5f;
        float minVel = 0.2f;

        if (Mathf.Abs(ballRb.velocity.x) < minVel)
        {
            velDelta = Random.value < 0.5 ? velDelta : -velDelta;
            ballRb.velocity += new Vector2(velDelta, 0f);
        }
        if (Mathf.Abs(ballRb.velocity.y) < minVel)
        {
            velDelta = Random.value < 0.5 ? velDelta : -velDelta;
            ballRb.velocity += new Vector2(0f, velDelta);
        }
    }
}
