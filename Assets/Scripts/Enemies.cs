using UnityEngine;

public class Enemies : MonoBehaviour
{
    private int Health = 20;

    public Transform[] movePoint;
    public GameObject dropItem;
    public int damages = 1;
    public int speed = 20;

    // Update is called once per frame
    void Update()
    {
        
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
        transform.Translate(transform.position);
    }
}
