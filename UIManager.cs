using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseManager<UIManager>
{
    [SerializeField]
    private MenuPanel menuPanel;
    public MenuPanel MenuPanel => menuPanel;

    [SerializeField]
    private LoadingPanel loadingPanel;
    public LoadingPanel LoadingPanel => loadingPanel;

    [SerializeField]
    private GamePanel gamePanel;

    public GamePanel GamePanel => gamePanel;

    [SerializeField]
    private SettingPanel settingPanel;
    public SettingPanel SettingPanel => settingPanel;

    [SerializeField]
    private PausePanel pausePanel;
    public PausePanel PausePanel => pausePanel;

    [SerializeField]
    private VictoryPanel victoryPanel;

    public VictoryPanel VictoryPanel => victoryPanel;


    [SerializeField]
    private LosePanel losePanel;

    public LosePanel LosePanel => losePanel;

    private void Start()
    {
        ActiveMenuPanel(true);
        ActiveSettingPanel(false);
        ActivePausePanel(false);
        ActiveLoadingPanel(false);
        ActiveVictoryPanel(false);
        ActiveLosePanel(false);
        ActiveGamePanel(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.HasInstance && GameManager.Instance.IsPlaying == true)
            {
                GameManager.Instance.PauseGame();
                ActivePausePanel(true);
            }
        }
    }
    internal void ActiveLoadingPanel(bool v)
    {
        loadingPanel.gameObject.SetActive(v);
    }

    internal void ActiveMenuPanel(bool v)
    {
        menuPanel.gameObject.SetActive(v);
    }

    internal void ActivePausePanel(bool v)
    {
        pausePanel.gameObject.SetActive(v);
    }

    internal void ActiveSettingPanel(bool v)
    {
        settingPanel.gameObject.SetActive(v);
    }
    internal void ActiveVictoryPanel(bool v)
    {
        victoryPanel.gameObject.SetActive(v);
    }

    internal void ActiveGamePanel(bool v)
    {
        gamePanel.gameObject.SetActive(v);
    }

    internal void ActiveLosePanel(bool v)
    {
        losePanel.gameObject.SetActive(v);
    }
}
