using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketPool : MonoBehaviour
{
    [SerializeField] private float preloadCount;
    [SerializeField] private GameObject rocketSample;
    
    /// <summary>
    /// Need to rework GameObject type to IRocket type so we can store different rocket types
    /// </summary>
    private HashSet<GameObject> rockets = new HashSet<GameObject>();
    public static RocketPool Instance;

    void Awake()
    {
        Boot();
        PreloadPool();
        DisableAllPool();
    }

    void Boot()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than 1 Singleton object, check scene hierarchy!");
        }
    }

    /// <summary>
    /// Preload needed amount of rockets, must be sat at Inspector
    /// </summary>
    void PreloadPool()
    {
        for (int i = 0; i < preloadCount; i++)
        {
            AddNewRocket();
        }
    }

    /// <summary>
    /// Hide all pool members
    /// </summary>
    void DisableAllPool()
    {
        foreach (var item in rockets)
        {
                item.SetActive(false);            
        }
    }
    

    /// <summary>
    /// Get rocket from pool, or create a new one 
    /// </summary>
    /// <returns></returns>
    public GameObject GetRocket()
    {
        foreach (var item in rockets)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }
        
        return AddNewRocket();
    }

    /// <summary>
    /// Create rocket and add it to the pool
    /// </summary>
    /// <returns></returns>
    GameObject AddNewRocket()
    {
        var newRocket = Instantiate(rocketSample, transform);
        newRocket.SetActive(false);
        rockets.Add(newRocket);
        return newRocket;
    }

}
