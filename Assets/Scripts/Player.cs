using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int health = 5;

    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isJumping = false;
    public GameObject axes;
    public Transform shootPoint;
    public bool win;
    
    private PlayerInventory inventoryPlater;
    private float moveInput;
    private Rigidbody2D rb2d;
    private InputAction throwAxe;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        throwAxe = InputSystem.actions.FindAction("Throw");
        inventoryPlater = rb2d.GetComponent<PlayerInventory>();
    }// Start


    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        rb2d.linearVelocity = new Vector2(moveInput * speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));

        }
        if (throwAxe.triggered)
        {
            StartCoroutine(DistanceAxe());
        }

        if (inventoryPlater.inventory["Tomato"] == 3 && inventoryPlater.inventory["Potato"] == 3 && inventoryPlater.inventory["Meat"] == 3 && !win)
        {
            win = true;
        }
    }// Update


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }//OnCollisionEnter2D


    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }//OnCollisionExit2D

    Vector2 ThrowAxe(Vector2 origin, float targetX, float targetY, float time)
    {
        float distanceX = targetX - origin.x;
        float distanceY = targetY - origin.y;

        // คำนวณความเร็วที่ต้องการในแต่ละแกน
        float velocityX = -distanceX / time;
        float velocityY = distanceY / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        // คืนค่าเป็น Vector2
        return new Vector2(velocityX, velocityY);
    }

    public void TakeDamages(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator DistanceAxe()
    {
        float distances = 0;
        float chargingTime = 0;

        while (throwAxe.IsPressed())
        {
            chargingTime += Time.deltaTime * 2;
            distances += Time.deltaTime;
            yield return null;

            if (chargingTime > 2)
            {
                break;
            }
        }

        if (chargingTime < 2)
        {
            yield break;
        }


        Vector2 projectileVelocity = ThrowAxe(shootPoint.position,distances,distances,chargingTime);

        Rigidbody2D firedBullet = Instantiate(axes.GetComponent<Rigidbody2D>(), shootPoint.position, Quaternion.identity);

        firedBullet.linearVelocity = projectileVelocity;

        Destroy(firedBullet,1);
    }
}
