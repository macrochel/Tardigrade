using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class task2Cast : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _val;
    private void Start()
    {
        StartCoroutine(Cast());
    }

    IEnumerator Cast()
    {
        _text.text = "";
        StartCoroutine(Text());
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("task2");
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
