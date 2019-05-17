using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    public PlayableDirector gameDirector;
    public Text keyUI;

    static Tuple<KeyCode, string>[] keys =
    {
        Tuple.Create(KeyCode.UpArrow, "↑"),
        Tuple.Create(KeyCode.DownArrow, "↓"),
        Tuple.Create(KeyCode.LeftArrow, "←"),
        Tuple.Create(KeyCode.RightArrow, "→")
    };

    bool isDisplayingKey;
    KeyCode currentKey;

    public void ShowRandomKey()
    {
        if (keyUI == null)
            return;

        if (!isDisplayingKey)
        {
            ShowKeyObject(true);
            DisplayRandomKey();
            isDisplayingKey = true;
        }
        else //player lost
        {
            ShowKeyObject(false);
            gameDirector.Stop();
        }
    }

    public void BeginGame()
    {
        if (keyUI != null)
            ShowKeyObject(false);
        isDisplayingKey = false;
    }

    void Update()
    {
        if (isDisplayingKey)
        {
            if (Input.GetKeyDown(currentKey))
            {
                ShowKeyObject(false);
                isDisplayingKey = false;
            }
        }
    }

    void ShowKeyObject(bool show)
    {
        var parent = keyUI.transform.parent.gameObject;
        parent.SetActive(show);
    }

    void DisplayRandomKey()
    {
        var keyIndex = Random.Range(0, keys.Length - 1);
        var (keyCode, keyString) = keys[keyIndex];
        currentKey = keyCode;
        keyUI.text = keyString;
    }
}
