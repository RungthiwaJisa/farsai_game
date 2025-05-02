using UnityEngine;

public class Enemies : MonoBehaviour
{
    private int Health = 20;
    private Vector2 velocity = new Vector2(-10,0);

    public Rigidbody2D rb;
    public Transform[] movePoint;
    public GameObject dropItem;
    public int damages = 1;

    private Vector2 targetPoint;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            Player play = collision.gameObject.GetComponent<Player>();

            if (collision.gameObject.CompareTag("Player"))
            {
                play.TakeDamages(damages);
            }
        }
    }

    public void TakeDamages(int damageTaken)
    {
        Health -= damageTaken;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(dropItem);

        Destroy(gameObject);
    }

    void Move()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoint[0].position.x && velocity.x < 0)
        {
            Flip();
        }
        else if (rb.position.x >= movePoint[1].position.x && velocity.x > 0)
        {
            Flip();
        }
        else if (velocity.y > 0 || velocity.y < 0)
        {
            if (rb.position.y <= movePoint[0].position.y && velocity.y < 0)
            {
                Flip();
            }
            else if (rb.position.y >= movePoint[1].position.y && velocity.y > 0)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        velocity *= -1;

        Vector3 charScale = transform.localScale;
        if (velocity.x > 0 || velocity.x < 0)
        {
            charScale.x *= -1;
        }
        else if (velocity.y > 0 || velocity.y < 0)
        {
            charScale.y *= -1;
        }
        transform.localScale = charScale;
    }
}
