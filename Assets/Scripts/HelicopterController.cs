using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private ParticleSystem explosion;
    private float speed;

    [SerializeField] private float helicopterSpeed;
    [SerializeField] private float topBoundary;

    [SerializeField] private GameController gameController;
    
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Helicopter collider" + collision.gameObject.tag);

        switch(collision.gameObject.tag)
        {
            case "missile":
                explosion.Play();
                SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
                gameController.HelicopterCrashed();
                Destroy(collision.gameObject);
                break;

            case "gold":
                SoundManager.Instance.Play(SoundManager.Sounds.CoinPickup);
                gameController.IncreaseScore(1);
                Destroy(collision.gameObject);
                break;

            case "collider":
                explosion.Play();
                SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
                gameController.HelicopterCrashed();
                break;

            case "powerup":
                collision.gameObject.GetComponent<IPowerup>().ApplyPowerup();
                break;
        }
    }
}
