using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite _musicImg;
    [SerializeField] private Sprite _muteImg;
    private bool isMuted;
    [SerializeField] private List<Button> _musicButtons;

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1;
        foreach (Button btn in _musicButtons)
        {
            btn.image.sprite = isMuted ? _muteImg : _musicImg;
            btn.onClick.AddListener(OnMusicButtonClick);
        }
    }
    public void OnMusicButtonClick()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
        foreach (Button btn in _musicButtons)
        {
            btn.image.sprite = isMuted ? _muteImg : _musicImg;
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void BackToStartGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
