using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _Prefabs;
    private int _side;
    private float _xPos = 13;

    #region Spawn
    void Start() => InvokeRepeating("SpawnForward", 1, 1);

    private void SpawnForward()
    {
        if (!PlayerController.gameOver)
        {
            _side = Random.Range(0, 4);
            Vector2 spawnPos = new Vector2(_xPos, Random.Range(-4f, 4f));
            Vector2 spawnRot = new Vector2(0f, 0f);
            Instantiate(_Prefabs[_side], spawnPos, Quaternion.Euler(spawnRot));
        }
    }
    #endregion
}
