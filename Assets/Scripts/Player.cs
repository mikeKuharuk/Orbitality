using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected float shootDelay = 2;
    [SerializeField] protected RocketLauncher rocketLauncher;
    [SerializeField] protected Text lifesCount;
    [SerializeField] protected GameObject explosionParticle;
    [SerializeField] private float deathAnimDelay = 0.5f;
    public readonly UnityEvent Dead = new UnityEvent();

    /// <summary>
    /// Shoot rocket in forward direction of the planet
    /// </summary>
    protected abstract void ShootRocket();
    
    
    /// <summary>
    /// Now we are waiting collision only from rocket, otherwise probably error 
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
      var rocket = collision.gameObject.GetComponent<IRocket>();
      if (rocket == null)
      {
          Debug.LogError("Unknown collision!");
          return;
      }
      HandleDamage(rocket.GetDamageCount());
    }

    /// <summary>
    /// Refresh lifes count text
    /// </summary>
    void RefreshUiStats()
    {
        lifesCount.text = health.ToString();
    }

    /// <summary>
    /// Calculate lifes left, die if less than 1
    /// </summary>
    /// <param name="damage"></param>
    void HandleDamage(int damage)
    {
        health -= damage;
        RefreshUiStats();
        if (health <= 0)
        {
            StartCoroutine(PlayDeathParticle());
        }
    }

    /// <summary>
    /// Play destroy particles, then disable object in scene
    /// </summary>
    void Die()
    {
        gameObject.SetActive(false);
        Dead.Invoke();
    }

    /// <summary>
    /// Enable particles, wait for anim, disable planet in game
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayDeathParticle()
    {
        explosionParticle.SetActive(true);
        yield return new WaitForSeconds(deathAnimDelay);
        Die();
    }
}
