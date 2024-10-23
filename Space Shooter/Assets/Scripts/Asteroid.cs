using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject explodePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAsteroid();
        RotateAsteroid();

        DestoryAfterCameraView();
    }

    public void Explode()
    {
        GameObject.Destroy(gameObject);

        GameObject newEffect;
        newEffect = Instantiate(explodePrefab, transform.position, Quaternion.identity);

        GameObject.Destroy(newEffect, 1.5f);
    }

    void DestoryAfterCameraView()
    {
        if (transform.position.z < -17)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void MoveAsteroid()
    {
        transform.Translate(0, 0,  -speed * Time.deltaTime,Space.World);
    }

    void RotateAsteroid()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }
}
