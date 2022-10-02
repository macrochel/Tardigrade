using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class task2Manager : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _val;
    [SerializeField] private GameObject _cast;
    [SerializeField] private Sprite _image2;
    [SerializeField] private Sprite _image3;
    [SerializeField] private Sprite _image4;
    private void Start()
    {
        StartCoroutine(Cast());
    }

    IEnumerator Cast()
    {
        _text.text = "";
        yield return new WaitForSeconds(0.7f);
        _cast.GetComponent<SpriteRenderer>().sprite = _image2;
        yield return new WaitForSeconds(0.7f);
        _cast.GetComponent<SpriteRenderer>().sprite = _image3;
        yield return new WaitForSeconds(0.7f);
        _cast.GetComponent<SpriteRenderer>().sprite = _image4;
        StartCoroutine(Text());
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("task3Preview");
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
