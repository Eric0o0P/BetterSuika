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
    private PlayerControl hitFruitControl;
    private GameObject hitFruit;

    // Start is called before the first frame update
    void Start()
    {
        fruitRb = GetComponent<Rigidbody>();

        //accessing spawn manager to assign an int for colour to check when coliding
        spawnManager = GameObject.Find("SpawnPoint").GetComponent<SpawnManager>();
        arrayNumber = spawnManager.smallFruit;
        fruitRb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canControl && transform.position.y > 27f)
        {
            UserControl();
        }
    }

    private void UserControl()
    {
        fruitRb.useGravity = false;

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
                int thisID = gameObject.GetInstanceID();
                int otherID = hitFruit.gameObject.GetInstanceID();

                if(thisID > otherID)
                {
                    int newFruitTier = arrayNumber + 1;
                    Vector3 newFruitPos = (transform.position + hitFruit.transform.position) / 2f;
                    Instantiate(spawnManager.fruitPrefabs[newFruitTier], newFruitPos, transform.rotation);
                

                    Destroy(gameObject);
                    Destroy(hitFruit);
                }
            }
        }

        //detecting 1st collision with ground or fruit
        if(collision.gameObject.CompareTag("fruit") || (collision.gameObject.CompareTag("ground")))
            
            for(int i = 0; i <= 1; i++)
            {
                hasCollided = true;
            }
    }

}
