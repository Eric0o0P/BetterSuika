using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool canControl = true;
    private Rigidbody fruitRb;
    private float moveSpeed = 20.0f;
    public bool hasCollided = false;
    public int arrayNumber;
    private SpawnManager spawnManager;
    public bool colidedWithColor = false;
    private PlayerControl hitFruitControl;
    private GameObject hitFruit;
    // Start is called before the first frame update
    void Start()
    {
        fruitRb = GetComponent<Rigidbody>();
        fruitRb.useGravity = false;

        //accessing spawn manager to assign an int for colour to check when coliding
        spawnManager = GameObject.Find("SpawnPoint").GetComponent<SpawnManager>();
        arrayNumber = spawnManager.smallFruit;
    }

    // Update is called once per frame
    void Update()
    {
        if(canControl)
        {
            UserControl();
        }
    }

    private void UserControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            fruitRb.useGravity = true;
            canControl = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //combination properties
        if(collision.gameObject.CompareTag("fruit"))
        {
            hitFruitControl = collision.gameObject.GetComponent<PlayerControl>();
            hitFruit = collision.gameObject;
            if(hitFruitControl.arrayNumber == arrayNumber)
            {
                
            }    
        }
        //detecting 1st collision
        for(int i = 0; i <= 1; i++)
        {
            hasCollided = true;
        }
    }
}
