using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class AIController : Player
{

    /// <summary>
    /// Right now just shoot everytime when rocket ready
    /// todo: Set aim, set difficulty level 
    /// </summary>
    void Start()
    {
        StartCoroutine(ShootAndReload());
    }

    /// <summary>
    /// Wait till rocket is ready again, than shoot
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootAndReload()
    {
        yield return new WaitForSeconds(shootDelay);
        ShootRocket();
        StartCoroutine(ShootAndReload());
    }
    
    protected override void ShootRocket()
    {
        rocketLauncher.Shoot();
    }
}
