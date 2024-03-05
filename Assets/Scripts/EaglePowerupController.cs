using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglePowerupController : SideScroll, IPowerup
{
    public EagleController eagleController;

    public void ApplyPowerup()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.EagleScreech);
        eagleController.gameObject.SetActive(true);

        Destroy(this.gameObject);
    }
}
