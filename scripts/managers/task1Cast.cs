using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class task1Cast : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _val;
    [SerializeField] private Image _cast;
    [SerializeField] private Sprite _image2;
    private void Start()
    {
        StartCoroutine(Cast());
    }

    IEnumerator Cast()
    {
        _text.text = "";
        yield return new WaitForSeconds(0.5f);
        _cast.sprite = _image2;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Text());
        yield return new WaitForSeconds(16.5f);
        SceneManager.LoadScene("task2CastPre");
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
