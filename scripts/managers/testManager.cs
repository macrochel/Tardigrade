using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testManager : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void True()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void False()
    {
        SceneManager.LoadScene("task2Dead");
    }
}
