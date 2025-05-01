using UnityEngine;

public class Enemies : MonoBehaviour
{
    private int Health = 200;

    public GameObject dropItem;
    public int damages = 1;
    public int speed = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
