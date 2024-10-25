using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        int numScenes = FindObjectsOfType<ScenePersist>().Length;

        if (numScenes > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenes()
    {
        Destroy(gameObject);
    }
}
