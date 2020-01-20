using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Player
{
    private bool reloaded = true;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) ShootRocket();
    }

    /// <summary>
    /// Shoot the rocket when its ready
    /// </summary>
    protected override void ShootRocket()
    {
        if(!reloaded) return;
        reloaded = false;
        rocketLauncher.Shoot();
        StartCoroutine(Reload());
    }

    /// <summary>
    /// Delay between shots
    /// </summary>
    /// <returns></returns>
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(shootDelay);
        reloaded = true;
    }
}
