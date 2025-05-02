using UnityEngine;

public class CollectingItems: MonoBehaviour
{
    [SerializeField] private string itemName;
    private int value = 1;
    [SerializeField] private bool destroyOnPickup = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าที่มาชนคือผู้เล่นหรือไม่
        if (other.CompareTag("Player"))
        {
            // ค้นหา PlayerInventory component บนตัวผู้เล่น
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                // เพิ่มไอเทมลงในคลังของผู้เล่น
                inventory.AddItem(itemName, value);

                // แสดงผลการเก็บ
                Debug.Log($"Player picked up {itemName} x{value}");

                // ทำลายไอเทมถ้าตั้งค่าไว้
                if (destroyOnPickup)
                {
                    Destroy(gameObject);
                }
            }
        }
    }


}
