using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyChase : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float chaseSpeed = 2.0f;
	private bool home = true;
	private Vector3 homePos;
    public int ownhp = 3;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float timer;
    public float Speed = 6;
    public GameObject EnemyCountText;
    public int enemiesLeft;

    private Vector2 moveDirection;

	public float maxMoveDistance = 10.0f;
	public float chaseTriggerDistance = 1.0f;

	void Start () {
		homePos = transform.position;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        PlayerPrefs.SetInt("EnemiesLeft", enemiesLeft);
    }
	
	// Update is called once per frame
	void Update () {
        EnemyCountText.GetComponent<Text>().text = ("Enemies Left: " + enemiesLeft);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        PlayerPrefs.SetInt("EnemiesLeft", enemiesLeft);
        timer += Time.deltaTime;
        if (ownhp <= 0)
        {
            enemiesLeft--;
            PlayerPrefs.SetInt("EnemiesLeft", PlayerPrefs.GetInt("EnemiesLeft") - 1);
            Destroy(this.gameObject);
        }
		float distanceToPlayer = 0.0f;
		Vector3 playerPosition = target.transform.position;
		moveDirection = new Vector2 (playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
		distanceToPlayer = moveDirection.magnitude;


        if (distanceToPlayer < chaseTriggerDistance)
        {
            moveDirection.Normalize();
            Fire();
            home = false;
            GetComponent<Rigidbody2D>().velocity = moveDirection * chaseSpeed;
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            ownhp = ownhp - 1;
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
            Vector3 foo2 = moveDirection * Speed;
            bullet.GetComponent<Rigidbody2D>().velocity = foo2 * Speed;

            // Destroy the bullet after 2 seconds
            timer = 0;
            Destroy(bullet, 2.0f);
        }
    }
}
