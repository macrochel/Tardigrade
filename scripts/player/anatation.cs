using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anatation : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _val;

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
    }
}
