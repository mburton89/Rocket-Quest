using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    [SerializeField] float secondsToDelayRestart;

    void Awake()
    {
        Instance = this;
    }

    public void RestartWithDelay()
    {
        StartCoroutine(RestartWithDelayCo());
    }

    private IEnumerator RestartWithDelayCo()
    {
        yield return new WaitForSeconds(secondsToDelayRestart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
