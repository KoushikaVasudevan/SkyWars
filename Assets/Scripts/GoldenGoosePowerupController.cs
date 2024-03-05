using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGoosePowerupController : SideScroll, IPowerup
{
    public MissileSpawner missileSpawner;
    public RewardsSpawner rewardsSpawner;

    public void ApplyPowerup()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.DuckQuack);

        rewardsSpawner.ActivateGoldenGoose();
        missileSpawner.ActivateGoldenGoose();
        Destroy(this.gameObject);
    }
}
