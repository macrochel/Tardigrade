using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveTo : MonoBehaviour
{
    [SerializeField, Range(0.1f, 50), Tooltip("Переменная для скорости")] private float _speed = 0.5f;
    Vector2 _targetPoint;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _blood;
    [SerializeField] private GameObject _next;
    [SerializeField] private Text _text;
    private string _val;
    private Rigidbody2D _rbody;
    // Start is called before the first frame update
    void Start()
    {
        _targetPoint = _player.transform.position;
        _rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        if (_speed != 0)
        {
            _rbody.velocity = new Vector2(_speed, - _player.transform.position.y);
        }
        yield return new WaitForSeconds(1);
    }

    IEnumerator Blood()
    {
        Debug.Log("blood");
        _blood.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        _next.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);
    }
    IEnumerator Text()
    {
        foreach (char abc in _val)
        {
            _text.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            _val = "A strange creature got into steve";
            _text.text = "";
            StartCoroutine(Text());
            _speed = 0f;
            _rbody.velocity = new Vector2(0, 0);
            StartCoroutine(Blood());
        }
    }





}
