using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    private GameManager _gameManager;
    private LevelManager _levelManager;
    public string levelName;


    private void Start()
    {
        _levelManager = FindAnyObjectByType<LevelManager>();
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Load()
    {
        _levelManager.LoadScene(levelName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            Load();
    }
}