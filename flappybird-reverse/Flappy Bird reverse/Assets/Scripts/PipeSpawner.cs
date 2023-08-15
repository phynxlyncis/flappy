using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    private float spawnRate = 3 ;
    private float timer = 0;
    

    public float heightOffset = 0.01f;
    public float gapSize = 2.075f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
            
        }
        else {
            spawnPipe();
            timer = 0;
        }

       
       
    }


    void spawnPipe()
    {
        // Get the lowest and highest point in the scene
        float lowestPoint = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y;
        float highestPoint = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane)).y;
    
        // Make sure there is room for the gap to flap between
        float lowestAllowedPoint = lowestPoint + gapSize;
        float highestAllowedPoint = highestPoint - gapSize;


        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestAllowedPoint, highestAllowedPoint), 0), transform.rotation);
    }

    //    Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

}
