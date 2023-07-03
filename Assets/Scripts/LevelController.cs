using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    Monster[] _monster;

    void OnEnable()
    {
        _monster = FindObjectsOfType<Monster>();
    }

    void Update()
    {
        if (MonsterAreAllDead())
        {
            GoToNextLevel();
        }
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to level " + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }

    bool MonsterAreAllDead()
    {
        foreach(var monster in _monster)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
