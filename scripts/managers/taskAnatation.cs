using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taskAnatation : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _val;
    [SerializeField] private string _val2;

    private void Start()
    {
        _text.text = "";
        StartCoroutine(Text());
    }


    IEnumerator Text()
    {
        foreach (char abc in _val)
        {
            _text.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Text2());
    }
    IEnumerator Text2()
    {
        _text.text = "";
        foreach (char abc in _val2)
        {
            _text.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
