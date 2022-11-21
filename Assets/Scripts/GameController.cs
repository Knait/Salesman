using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StateGame
{
    Start,
    Game,
    WinGame,
    LoseGame
}

/// <summary>
/// Game Controller логика игры,содержит ссылки на игрока, шарики и противников
/// </summary>

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    /// <summary>
    /// текущее колво обслужанных клиентов
    /// </summary>
    [HideInInspector]
    public int countServedShoppers;
    [HideInInspector]
    public int currentTimerGame;

    [Header("Ссыль SpawnerShoppers")]
    [SerializeField]
    public SpawnerShoppers spawnerShoppers;
    [Header("Ссыль на панель Старт Игра")]
    [SerializeField]
    public GameObject PanelStartGame;
    [Header("Ссыль на панель Game")]
    [SerializeField]
    public GameObject PanelGame;
    [Header("Ссыль на панель Победы игрока")]
    [SerializeField]
    private GameObject PanelWinGame;
    [Header("Ссыль на панель Поражения игрока")]
    [SerializeField]
    private GameObject PanelLoseGame;
    [Header("Задержка на появление панель Win/Lose")]
    [SerializeField]
    private float delayOnPanelWinLose = 1.0f;
    [Header(" Массив точки покупки")]
    public Transform[] PointsBuy;
    public int currentLevel;   //   текущий уровень 
    [HideInInspector]
    public bool isPlayGame;
    public StateGame stateGame;
    [HideInInspector]
    public int currentHealthCastle; // текущее здоровье замка
    [HideInInspector]
    public int currentCountBots;   //  текущее кол-во ботов

    /// <summary>
    /// текущее кол-во бабла
    /// </summary>
    public int currentMoney;  //  текущее кол-во бабла

    [HideInInspector]
    public int allMoney;      // всего денях
    [HideInInspector]
    public int currentIDSkin;   // текущий ID skin
    [HideInInspector]
    public int upgradeDobleShootLevel;     //  // текущий Level DoubleShoot
    [HideInInspector]
    public int currentPriceDoubleShoot;    // цена прокачки DoubleShoot
    [HideInInspector]
    public int upgradeSpeedHeroLevel;      //  // текущий Level SpeedHero
    [HideInInspector]
    public int currentPriceSpeedHero;     // цена прокачки SpeedHero


    void Awake()
    {
        Instance = this;
        PanelGame.SetActive(false);
        PanelWinGame.SetActive(false);
        PanelLoseGame.SetActive(false);
        spawnerShoppers.gameObject.SetActive(false);
        PanelStartGame.gameObject.SetActive(true);

        currentLevel = LoadData("LevelNumber");          /// З А Г Р У З К А     Л Е В Е Л А /////////////////////////////////

        if (currentLevel == 0)
        {
            currentLevel = 1;
        }

        allMoney = LoadData("Money");
        currentIDSkin = LoadData("SavedIDSkin");
        SetLoadScene(currentLevel);
    }


    void Start()
    {
        isPlayGame = true;
        stateGame = StateGame.Start;
        currentTimerGame = GameSettings.Instance.maxTimeGame;
        StartCoroutine(TimerGame());
    }

    private void Update()
    {
        if (isPlayGame)
        {
            UpdateGame();
            UpdateStateGame();
        }
    }

    void UpdateGame()
    {
        if (currentHealthCastle <= 0)
        {
            stateGame = StateGame.LoseGame;
        }

        if (currentTimerGame <= 0)
        {
            stateGame = StateGame.WinGame;
        }
    }

    /// <summary>
    /// обновление игры
    /// </summary>
    public void UpdateStateGame()
    {

        if (stateGame == StateGame.LoseGame)
        {
            isPlayGame = false;
            EndGame();
            Invoke("LoseGame", delayOnPanelWinLose);
        }

        if (stateGame == StateGame.WinGame)
        {
            isPlayGame = false;
            EndGame();
            Invoke("WinGame", delayOnPanelWinLose);
        }

        if (stateGame == StateGame.Game)
        {
            StartGame();
        }

    }

    /// <summary>
    /// старт игры
    /// </summary>
    public void StartGame()
    {
        stateGame = StateGame.Game;
        spawnerShoppers.gameObject.SetActive(true);
        PanelStartGame.SetActive(false);
        PanelGame.SetActive(true);
    }

    /// <summary>
    /// конец игры
    /// </summary>
    public void EndGame()
    {
        spawnerShoppers.gameObject.SetActive(false);
        PanelGame.SetActive(false);
        SaveData("LevelNumber", currentLevel);                            // сохраняем номер level
        int saveMoney = currentMoney + allMoney;
        SaveData("Money", saveMoney);                                 // сохраняем колво денег
        StartCoroutine(ShowAnimationMoney());
    }


    /// <summary>
    /// Победа
    /// </summary>
    void WinGame()
    {
        currentLevel++;
        currentMoney += GameSettings.Instance.countMoneyGame;
        EndGame();
        PanelWinGame.SetActive(true);
    }


    /// <summary>
    /// Проигрыш
    /// </summary>
    void LoseGame()
    {
        EndGame();
        PanelLoseGame.SetActive(true);
    }

    private IEnumerator ShowAnimationMoney()
    {
        float timerShowAnimationMoney = 0.1f;
        while (currentMoney > 0)
        {
            currentMoney--;
            allMoney++;
            yield return new WaitForSeconds(timerShowAnimationMoney); 
        }
    }

    /// <summary>
    /// Таймер игры
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimerGame()
    {
        while (currentTimerGame > 0)
        {
            yield return new WaitForSeconds(1.0f);
            if (stateGame == StateGame.Game)
            {
                currentTimerGame--;
            }
        }
    }

    /// <summary>
    /// Выбор сцены для загрузки
    /// </summary>
    /// <param name="currentLevel"></param>
    /// <returns></returns>
    int SetLoadScene(int currentLevel)
    {
        int result = 0;
        if (currentLevel > 20)
        {
            LoadScene(Random.Range(0, 21));
        }
        else
        {
            LoadScene(currentLevel);
        }
        return result;
    }

    public void LoadScene(int currentScene)
    {
        int tempLoadScene = currentScene - 1;

        if (SceneManager.GetActiveScene().buildIndex != tempLoadScene)
        {
            if ((SceneManager.sceneCountInBuildSettings - 2) >= tempLoadScene)
            {
                tempLoadScene = currentScene - 1;
                SceneManager.LoadScene(tempLoadScene);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Сохранение данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <param name="Value"></param>
    public void SaveData(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    /// <param name="KeyName"></param>
    /// <returns></returns>
    public int LoadData(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    public void SetCurrentMoney(int money)
    {
        currentMoney += money;
        currentMoney = currentMoney < 0 ? 0 : currentMoney;
    }

    public void SetCountServedShoppers() => countServedShoppers++;
}
