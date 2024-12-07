using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Colletable
{
    public int value = 1; // จำนวนเหรียญที่เพิ่ม

    public override void Collect(Character character)
    {
        CoinManager coinManager = FindObjectOfType<CoinManager>();
        if (coinManager != null)
        {
            coinManager.coinCount += value;
            Debug.Log("Coins Collected: " + coinManager.coinCount);
        }
        Destroy(this.gameObject); // ลบเหรียญหลังจากเก็บ
    }
}
