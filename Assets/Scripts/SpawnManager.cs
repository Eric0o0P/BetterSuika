using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] fruitPrefabs;
    private GameObject currentFruit;
    private PlayerControl playerControl;
    public int smallFruit;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomFruit();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControl.hasCollided == true)
        {
            SpawnRandomFruit();
        }
    }

    private void SpawnRandomFruit()
    {
        smallFruit = Random.Range(0, 7 - 4);
        currentFruit = Instantiate(fruitPrefabs[smallFruit], transform.position, fruitPrefabs[smallFruit].transform.rotation) as GameObject;

        playerControl = currentFruit.GetComponent<PlayerControl>();
    }
}
