using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneReset : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector playableDirector;

    private void OnEnable()
    {
        playableDirector.stopped += ResetScene;
    }

    private void ResetScene(PlayableDirector obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDisable()
    {
        playableDirector.stopped += ResetScene;
    }
}
