using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveForwardX : MonoBehaviour
{
    #region Initialize
    [SerializeField] private float _speed;
    [SerializeField] private Text _text;
    [SerializeField] private string _val;
    [SerializeField] private Rigidbody2D _rbody;
    [SerializeField] private float _horizontalInput;

    private void Awake()
    {
        _horizontalInput = _speed;
        _rbody = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Update
    private void Update()
    {
        if (!PlayerController.gameOver)
        {
            _rbody.velocity = new Vector2(-_horizontalInput, _rbody.velocity.y);
        }
        else
        {
            _rbody.velocity = new Vector2(0, 0);
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }


}
