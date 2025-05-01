using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    [SerializeField] private TMP_Text potatoes;
    [SerializeField] private TMP_Text tomatoes;
    [SerializeField] private TMP_Text meat;

    public void AddItem(string itemName, int amount = 1)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] += amount;
        }
        else
        {
            inventory.Add(itemName, amount);
        }

        // อัพเดท UI แสดงคลัง
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        if (inventory.ContainsKey("Tomato"))
        {
            Updatetomatoes(inventory["Tomato"]);
        }
        else if (inventory.ContainsKey("Potato"))
        {
            UpdatePotatoes(inventory["Potato"]);
        }
        else if (inventory.ContainsKey("Meat"))
        {
            UpdateMeats(inventory["Meat"]);
        }
    }

    public bool HasItem(string itemName, int amount = 1)
    {
        return inventory.ContainsKey(itemName) && inventory[itemName] >= amount;
    }

    // เมทอดสำหรับดูจำนวนไอเทมที่มี
    public int GetItemCount(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            return inventory[itemName];
        }
        return 0;
    }

    public void UpdatePotatoes(int amount)
    {
        potatoes.text = $"{amount}";
    }
    public void Updatetomatoes(int amount)
    {
        tomatoes.text = $"{amount}";
    }
    public void UpdateMeats(int amount)
    {
        meat.text = $"{amount}";

    }
}
