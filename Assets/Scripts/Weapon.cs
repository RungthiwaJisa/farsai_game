using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int damages;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Enemies en = collision.gameObject.GetComponent<Enemies>();

            if (collision.gameObject.CompareTag("Enemy"))
            {
                en.TakeDamages(damages);

                Destroy(gameObject);
            }
        }
    }
}
