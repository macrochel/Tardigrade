using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Initialize
    [SerializeField, Range(1, 50), Tooltip("Переменная для скорости")] private float _speed = 5f;
    private Rigidbody2D _rbody;
    [SerializeField] private GameObject _next;
    [SerializeField] private int _scene;
    [SerializeField] private string[] _questions;
    [SerializeField] private float _verticalInput;
    [SerializeField] private Text _txt;
    [SerializeField] private Text _recordTxt;
    [SerializeField] private Text _questTxt;
    [SerializeField] private bool _upMove;
    [SerializeField] private bool _downMove;
    [SerializeField] private GameObject _fact;
    static public bool gameOver;
    [SerializeField] static public int bar;
    static public bool pause;
    private void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _upMove = false;
        _downMove = false;
    }
    #endregion

    #region Movement
    private void Update()
    {
        if (_scene == 0)
        {
            sceneManager.Record = PlayerPrefsSafe.GetInt("Record", sceneManager.Record);
            if (bar > sceneManager.Record)
            {
                PlayerPrefsSafe.SetInt("Record", bar);
            }
            _recordTxt.text = $"record: {sceneManager.Record}";
            if (!sceneManager.Check)
            {
                giveFact(bar, _questions, _questTxt);
            }
        }
        if (!gameOver)
        {
            Move();
            _rbody.velocity = new Vector2(_rbody.velocity.x, _verticalInput);
        }
        else if (gameOver)
        {
            _rbody.velocity = new Vector2(0, 0);
            if (_scene == 1)
            {
                StartCoroutine(nextScene());
            }
        }
        
    }

    public void MoveUUp()
    {
        _upMove = false;
    }

    public void MoveUDown()
    {
        _upMove = true;
    }

    public void MoveDUp()
    {
        _downMove = false;
    }

    public void MoveDDown()
    {
        _downMove = true;
    }

    private void Move()
    {
        if (_downMove && !gameOver)
        {
            _verticalInput = -_speed;
        }

        else if (_upMove && !gameOver)
        {
            _verticalInput = _speed;
        }

        else
        {
            _verticalInput = 0;
        }
    }

    public void giveFact(int bar, string[] questions, Text text)
    {
        if (bar == 20 && !sceneManager.Check)
        {
            text.text = questions[0];
            sceneManager.Fact(_fact);
        }

        else if (bar == 40 && !sceneManager.Check)
        {
            text.text = questions[1];
            sceneManager.Fact(_fact);
        }

        else if (bar == 60 && !sceneManager.Check)
        {
            text.text = questions[2];
            sceneManager.Fact(_fact);
        }

        else if (bar == 80 && !sceneManager.Check)
        {
            text.text = questions[3];
            sceneManager.Fact(_fact);
        }

        else if (bar == 100 && !sceneManager.Check)
        {
            text.text = questions[4];
            sceneManager.Fact(_fact);
        }

        else if (bar == 120 && !sceneManager.Check)
        {
            text.text = questions[5];
            sceneManager.Fact(_fact);
        }

        else if (bar == 140 && !sceneManager.Check)
        {
            text.text = questions[6];
            sceneManager.Fact(_fact);
        }

        else if (bar == 160 && !sceneManager.Check)
        {
            text.text = questions[7];
            sceneManager.Fact(_fact);
        }

        else if (bar == 180 && !sceneManager.Check)
        {
            text.text = questions[8];
            sceneManager.Fact(_fact);
        }

        else if (bar == 200 && !sceneManager.Check)
        {
            text.text = questions[9];
            sceneManager.Fact(_fact);
        }
    }

    #endregion

    IEnumerator nextScene()
    {
        if (!pause && gameOver)
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("task1Cast");
        }

    }

    #region Collision

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ambit"))
        {
            gameOver = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rad"))
        {
            Destroy(collision.gameObject);
            bar += 1;
            _txt.text = $"radiation: {bar}";
            sceneManager.Check = false;
        }

        if (collision.gameObject.CompareTag("rocket") && bar > 5)
        {
            Destroy(collision.gameObject);
            bar -= 5;
            _txt.text = $"radiation: {bar}";
        }

        else if (collision.gameObject.CompareTag("rocket") && bar < 5)
        {
            Destroy(collision.gameObject);
            bar = 0;
            _txt.text = $"radiation: {bar}";
        }
        #endregion
    }
}