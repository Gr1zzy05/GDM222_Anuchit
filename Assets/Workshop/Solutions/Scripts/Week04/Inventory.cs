using Solution;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // ใช้ Dictionary เพื่อเก็บข้อมูล ItemData คู่กับ จำนวน (int)
    public Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();

    // 1. เพิ่มไอเท็ม
    public void AddItem(ItemData item, int amount)
    {
        if (items.ContainsKey(item))
        {
            // ถ้ามีไอเท็มนี้อยู่แล้ว ให้บวกจำนวนเพิ่มเข้าไป
            items[item] += amount;
        }
        else
        {
            // ถ้ายังไม่มี ให้เพิ่ม Key ใหม่เข้าไปใน Dictionary
            items.Add(item, amount);
        }
        Debug.Log($"Added {amount} of {item.name}. Total: {items[item]}");
    }

    // 2. ลบไอเท็ม (ใช้งาน)
    public void UseItem(ItemData item, int amount)
    {
        if (HasItem(item, amount))
        {
            items[item] -= amount;
            Debug.Log($"Used {amount} of {item.name}. Remaining: {items[item]}");

            // ออปชั่นเสริม: ถ้าเหลือ 0 จะลบออกจาก Dictionary เลยก็ได้ เพื่อไม่ให้รก
            if (items[item] <= 0)
            {
                items.Remove(item);
            }
        }
        else
        {
            Debug.LogWarning($"Not enough {item.name} to use!");
        }
    }

    // 3. ตรวจสอบว่ามีไอเท็มเพียงพอหรือไม่
    public bool HasItem(ItemData item, int amount)
    {
        // ตรวจสอบว่ามี Key นี้อยู่ และจำนวนใน Value ต้องมากกว่าหรือเท่ากับที่ต้องการ
        return items.ContainsKey(item) && items[item] >= amount;
    }

    // 4. ตรวจสอบจำนวนไอเท็มที่มีอยู่
    public int GetItemCount(ItemData item)
    {
        if (items.ContainsKey(item))
        {
            return items[item];
        }
        return 0; // ถ้าไม่มีไอเท็มนั้นเลยให้คืนค่า 0
    }

    // 5. แสดงรายการทั้งหมดในคลัง (สำหรับ Debug)
    public void PrintInventory()
    {
        Debug.Log("--- Current Inventory ---");
        foreach (var pair in items)
        {
            // pair.Key คือ ItemData, pair.Value คือจำนวน
            Debug.Log($"Item: {pair.Key.name} | Amount: {pair.Value}");
        }
        if (items.Count == 0) Debug.Log("Inventory is empty.");
    }
}