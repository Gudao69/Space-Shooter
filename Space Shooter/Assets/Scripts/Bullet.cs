using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        DestoryAfterCameraView();
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Asteroid") )
        {
            GameObject.Destroy(gameObject);

            Asteroid asteroid;
            asteroid = other.GetComponent<Asteroid>();
            asteroid.Explode();


            Player gamePlayer;
            gamePlayer = FindObjectOfType<Player>();
            gamePlayer.GiveScore();
        }
    }

    void DestoryAfterCameraView()
    {
        if (transform.position.z > 50)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void MoveForward()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
