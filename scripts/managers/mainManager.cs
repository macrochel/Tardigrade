using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _cast;
    [SerializeField] private string _scene;

    private void Start()
    {
        StartCoroutine(NextImage());
    }

    IEnumerator NextImage()
    {
        foreach (Sprite img in _sprites)
        {
            _cast.sprite = img;
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(_scene);
    }
}
