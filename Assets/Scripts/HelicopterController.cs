using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private ParticleSystem explosion;
    private float speed;

    [SerializeField] private float helicopterSpeed;
    [SerializeField] private Transform ShotPoint;
    [SerializeField] private float topBoundary;

    //[SerializeField] private GameObject EnemyBullet;
    [SerializeField] private GameController gameController;
    //[SerializeField] private float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        explosion = GetComponent<ParticleSystem>();

        speed = helicopterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position.y >= topBoundary)
            {
                speed = 0;
            }
            else
            {
                speed = helicopterSpeed;
            }
            rb2d.velocity = transform.up * speed;
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            Instantiate(EnemyBullet, ShotPoint.transform.position, ShotPoint.transform.rotation);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "missile")
        {
            explosion.Play();
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);

            gameController.HelicopterCrashed();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "gold")
        {
            SoundManager.Instance.Play(SoundManager.Sounds.CoinPickup);
            gameController.IncreaseScore(1);

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "collider")
        {
            explosion.Play();
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);

            gameController.HelicopterCrashed();
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }
}
