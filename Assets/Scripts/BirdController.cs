using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "missile")
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "gold")
        {
            SoundManager.Instance.Play(SoundManager.Sounds.CoinPickup);
            gameController.IncreaseScore(1);
            Destroy(collision.gameObject);
        }
    }
}
