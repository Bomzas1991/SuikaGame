using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int Fruits;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name.Contains("Fruit"))
        {
            Fruits++;
        }
    }
}
