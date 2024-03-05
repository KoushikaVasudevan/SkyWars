using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsPowerupController : SideScroll, IPowerup
{
    public GameObject FlockOfBirds;

    public void ApplyPowerup()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.BirdsFlap);
        FlockOfBirds.SetActive(true);

        Destroy(this.gameObject);
    }
}
