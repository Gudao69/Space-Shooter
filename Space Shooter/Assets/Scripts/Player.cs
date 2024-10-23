using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public int score;
    public int life;
    public GameObject bulletPrefab;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
        ShootBullet();
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Asteroid") )
        {
            life -= 1;

            Asteroid asteroid;
            asteroid = other.GetComponent<Asteroid>();
            asteroid.Explode();

            if ( life <= 0 )
            {
                PlayerPrefs.SetInt("MyScore", score);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void GiveScore()
    {
        score += 1;
        scoreText.text = "Score :" + score;
    }

    void ShootBullet()
    {
        if( Input.GetKeyUp(KeyCode.Space ) )
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void ClampPlayerPosition()
    {
        float clampX = Mathf.Clamp(transform.position.x, -11, 11);
        float clampZ = Mathf.Clamp(transform.position.z, -7, 40);
        transform.position = new Vector3(clampX, 0, clampZ);
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(-horizontal, 0, -vertical);
    }

}
