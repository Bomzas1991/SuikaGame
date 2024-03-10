using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePosition;
    public bool touchingFloor;
    GameManager NewFruit;

    public GameObject Fruit;
    public int pointsToAdd;
    public TextMeshPro points;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        NewFruit = GetComponent<GameManager>();

        rb.bodyType = RigidbodyType2D.Kinematic;
        if (transform.position.y == 4)
        {
            touchingFloor = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0) == true && touchingFloor == false)
        {
            Drop();
        }
    }

    public void Drop()
    {
        transform.position = new Vector2(mousePosition.x, 4);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Contains("Floor"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            touchingFloor = true;
            NewFruit.NewFruit = true;
        }
        if (collision.transform.tag == transform.tag)
        {
            Destroy(gameObject);
            int text = int.Parse(points.text);
            text += pointsToAdd;
            points.text = text.ToString();

            if (touchingFloor)
            {
                Instantiate(Fruit, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Contains("End"))
        {
            print("GameOver");
        }
    }
}
