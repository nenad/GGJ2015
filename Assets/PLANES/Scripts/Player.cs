using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static float X_BOUNDARY = 3.5f;
    public static float Y_BOUNDARY = -3f;
    public float speed = 10;
    public Bullet bullet;
    public int Health;
    private Vector3 startPosition;
    Transform planetgame;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        Y_BOUNDARY = startPosition.y;
        planetgame = GameObject.FindObjectOfType<PlanesGame>().transform;
	}
	
	// Update is called once per frame
	void Update () {
	
        var x = Input.GetAxis("Horizontal");
        //var y = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x * Time.deltaTime * speed, 0, 0));
        if (transform.position.x < -X_BOUNDARY + startPosition.x)
        {
            transform.position = new Vector3(-X_BOUNDARY + startPosition.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > X_BOUNDARY + startPosition.x)
        {
            transform.position = new Vector3(X_BOUNDARY + startPosition.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y != Y_BOUNDARY)
        {
            transform.position = new Vector3(transform.position.x, Y_BOUNDARY, transform.position.z);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            var b = Instantiate(bullet, transform.position + new Vector3(0,1.3f), Quaternion.identity) as Bullet;
            b.shooter = gameObject;
            b.direction = Vector3.up;
            b.origin = transform.position;
        }

        if (Health <= 0)
        {
            Die();
        }
    }

    public void ResetPlayer()
    {
        Health = 100;
        transform.position = new Vector3(0, Y_BOUNDARY);
    }

    private void Die()
    {
        Reset r = GameObject.FindObjectOfType<Reset>();
        r.ResetGame();
    }

}
