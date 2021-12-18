using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Playercontroller : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movimentX;
    private float movimentY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove (InputValue movimentValue) {
        Vector2 movimentVector = movimentValue.Get<Vector2>();

        movimentX = movimentVector.x;
        movimentY = movimentVector.y;

    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if (count >= 12) {
            winTextObject.SetActive(true);
        }
    }
    void FixedUpdate () {
        Vector3 moviment = new Vector3(movimentX, 0.0f, movimentY);
        rb.AddForce(moviment * speed);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        
    }
}
