using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int healthIncrease = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            character.TakePotion(healthIncrease);
            Destroy(this.gameObject);
        }
    }
}
