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
    [SerializeField] private GameObject _endgamePanel;
    public bool stopGame = false;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        foreach (Button btn in _musicButtons)
        {
            btn.image.sprite = _musicImg;
            btn.onClick.AddListener(() => OnMusicButtonClick(btn));
        }
    }
    public void OnMusicButtonClick(Button clickedButton)
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            clickedButton.image.sprite = _muteImg;
        }
        else
        {
            clickedButton.image.sprite = _musicImg;
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        if (_endgamePanel != null)
            _endgamePanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void BackToStartGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void PauseGame()
    {
        stopGame = true;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _endgamePanel.SetActive(true);
    }

  
    //private IEnumerator CountdownBeforeResume(float countdownTime)
    //{
    //    _timeCountDownPanel.SetActive(true);
    //    Time.timeScale = 1;
    //    while (countdownTime > 0)
    //    {
    //        timeCountDown.text = Mathf.Ceil(countdownTime).ToString();
    //        yield return new WaitForSeconds(1);
    //        countdownTime--;
    //    }
    //    stopGame = false;
    //    SpawBlock.Instance.SetStaticRigid(false);
    //    _timeCountDownPanel.SetActive(false);
    //    timeCountDown.text = "3";
    //}


}
