﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExample : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;
    public Joystick joystick2;
    public Vector3 joyStartPos;
    public GameObject handle;
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float timer;
    public float Speed = 2;
    private void Start()
    {
        joyStartPos = handle.transform.position;
    }
    void Update () 
	{
        if (PlayerPrefs.GetInt("EnemiesLeft") <= 0)
        {
            PlayerPrefs.SetInt("EnemiesLeft", 1);
            if (PlayerPrefs.GetInt("lvlnum") == 1)
            {
                PlayerPrefs.SetInt("EnemiesLeft", 1);
                PlayerPrefs.SetInt("lvlnum", 2);
            }
            if (PlayerPrefs.GetInt("lvlnum") == 2 && PlayerPrefs.GetInt("lvl1c") == 1)
            {
                PlayerPrefs.SetInt("EnemiesLeft", 1);
                PlayerPrefs.SetInt("lvlnum", 3);
            }
            if (PlayerPrefs.GetInt("lvlnum") == 3 && PlayerPrefs.GetInt("lvl2c") == 1 && PlayerPrefs.GetInt("lvl1c") == 1)
            {
                PlayerPrefs.SetInt("EnemiesLeft", 1);
                PlayerPrefs.SetInt("lvlnum", 4);
            }
            SceneManager.LoadScene("transition");
        }
        timer += Time.deltaTime;
        Vector3 moveVector = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;//(transform.right * joystick.Horizontal + transform.up * joystick.Vertical).normalized;
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVector*moveSpeed *Time.deltaTime;//transform.Translate(moveVector * moveSpeed * Time.deltaTime);
        Vector3 rotateVector = (transform.right * joystick2.Horizontal*180 + transform.up * joystick2.Vertical*180);
        /*if x < 0 y == 0
         * looking right
         * rotate 90 degrees clockwise
         * if x > 0 y == 0
         * looking left
         * rotate 90 degrees counterclockwise
         * if y < 0
         * looking down
         * rotate 180 degrees
         * if y > 0
         * looking up
         * rotate 0 degrees
         * 
         * */
        Vector3 foo = (handle.transform.position - joyStartPos).normalized;
        if (foo.magnitude == 1)
        {
            Fire();
            transform.forward = foo;
            player.transform.Rotate(new Vector3(0, 90, 90));
            //transform.rotation = Quaternion.Euler(rotateVector);
        }
    }
    void Fire()
    {
        if (timer >= 0.3)
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            // Add velocity to the bullet
            Vector3 foo2 = (handle.transform.localPosition).normalized * Speed;
            bullet.GetComponent<Rigidbody2D>().velocity = foo2;// * Speed;

            // Destroy the bullet after 2 seconds
            timer = 0;
            Destroy(bullet, 2.0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 2);
        }
        if (collision.gameObject.layer == 11)
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 1);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 2);
            Destroy(collision.gameObject);
        }
    }
}