using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool NewFruit = false;
    public GameObject[] Fruits;
    Floor Fruitsa;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NewFruit == true)
        {
            int rnd = Random.Range(0, 8);
            Instantiate(Fruits[rnd], transform.position, Quaternion.identity);
            //NewFruit = false;
        }
        //Fruitsa = GetComponent<Floor>();

        //if (Fruitsa.Fruits == 3)
        //{
        //    int rnd = Random.Range(0, 8);
        //    Instantiate(Fruits[rnd], transform.position, Quaternion.identity);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name.Contains("Fruit"))
        {
            return;
        }
    }
}
