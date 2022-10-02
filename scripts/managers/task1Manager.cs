using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class task1Manager : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _val;
    [SerializeField] private Image _cast;
    [SerializeField] private Sprite _image2;
    [SerializeField] private Sprite _image3;
    private void Start()
    {
        StartCoroutine(Cast());
    }

    IEnumerator Cast()
    {
        _text.text = "";
        yield return new WaitForSeconds(0.9f);
        _cast.sprite = _image2;
        yield return new WaitForSeconds(0.9f);
        _cast.sprite = _image3;
        yield return new WaitForSeconds(0.9f);
        _cast.gameObject.SetActive(false);
        StartCoroutine(Text());
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("task1Cast2");
    }

    IEnumerator Text()
    {
        foreach (char abc in _val)
        {
            _text.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
