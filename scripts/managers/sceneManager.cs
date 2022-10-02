using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
    #region Initialize
    [SerializeField] private GameObject _fact;
    [SerializeField] private GameObject _pauseBar;
    static public bool Check;
    public static int Counter;
    public static int Record;
    #endregion

    #region Methods

    private void Awake()
    {
        if (PlayerPrefsSafe.HasKey("Counter"))
        {
            Counter = PlayerPrefsSafe.GetInt("Counter", Counter);
        }

        else
        {
            PlayerPrefsSafe.SetInt("Counter", 0);
            Counter = PlayerPrefsSafe.GetInt("Counter", Counter);
        }

        if (PlayerPrefsSafe.HasKey("Record"))
        {
            Record = PlayerPrefsSafe.GetInt("Record", Record);
        }

        else
        {
            PlayerPrefsSafe.SetInt("Record", 0);
            Record = PlayerPrefsSafe.GetInt("Record", Record);
        }
    }

    public void Scenes(string name)
    {
        SceneManager.LoadScene(name);
        PlayerController.gameOver = false;
        PlayerController.bar = 0;
        Check = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerController.gameOver = false;
        PlayerController.bar = 0;
        Check = false;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void ResetRecord()
    {
        PlayerPrefsSafe.SetInt("Record", 0);
        Record = PlayerPrefsSafe.GetInt("Record", Record);
    }

    public void Pause()
    {
        if (!PlayerController.gameOver)
        {
            _pauseBar.SetActive(true);
            PlayerController.pause = true;
            PlayerController.gameOver = true;
        }
    }

    public static void Fact(GameObject _fact)
    {
        if (!PlayerController.gameOver)
        {
            _fact.SetActive(true);
            PlayerController.gameOver = true;
            Check = true;
        }
    }

    public static void FactResume(GameObject _fact)
    {
        PlayerController.gameOver = false;
        _fact.SetActive(false);
    }

    public void StartPlot()
    {
        Counter = PlayerPrefsSafe.GetInt("Counter", Counter);
        PlayerController.gameOver = false;
        PlayerController.bar = 0;
        Check = false;
        if (Counter == 1)
        {
            Scenes("task3");
        }

        else
        {
            Scenes("main");
        }
    }

    public void EndPlot()
    {
        PlayerPrefsSafe.SetInt("Counter", 1);
        Counter = PlayerPrefsSafe.GetInt("Counter", Counter);
    }

    public void Resume()
    {
        PlayerController.gameOver = false;
        _pauseBar.SetActive(false);
        StartCoroutine(resume());
    }

    IEnumerator resume()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerController.pause = false;
    }
    #endregion
}
