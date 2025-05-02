using UnityEngine;

public class Doremondoor : MonoBehaviour
{
    [SerializeField]Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Player>();

        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.inventoryPlater.inventory != null)
            {
                if (player.inventoryPlater.inventory["Tomato"] >= 3 && player.inventoryPlater.inventory["Potato"] >= 3 && player.inventoryPlater.inventory["Meat"] >= 1 && !player.isGameWin)
                {
                    player.isGameWin = true;
                }
            }
        }
    }
}
