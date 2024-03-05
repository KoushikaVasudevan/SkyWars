using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour, IPowerup
{
    [SerializeField] private HelicopterController helicopterController;
    [SerializeField] private GameController gameController;

    [SerializeField] private float coolDownTime = 5f;
    [SerializeField] private float activeEagleTime;
    [SerializeField] private float eagleYPos;
    [SerializeField] private float helicopterYPos;

    private void Start()
    {
        activeEagleTime = coolDownTime;

        eagleYPos = transform.position.y;
        helicopterYPos = helicopterController.gameObject.transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        
        activeEagleTime -= Time.deltaTime;

        eagleYPos = helicopterYPos;

        if (activeEagleTime <= 0)
        {
            gameObject.SetActive(false);

        }
    }

    public void ApplyPowerup()
    {
        activeEagleTime = coolDownTime;
        SoundManager.Instance.Play(SoundManager.Sounds.EagleScreech);
        gameObject.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "missile")
        {
            //explosion.Play();
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "gold")
        {
            SoundManager.Instance.Play(SoundManager.Sounds.CoinPickup);
            gameController.IncreaseScore(1);
            Destroy(collision.gameObject);
        }
    }
}
