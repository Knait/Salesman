/// висит на GameController управляет игровой логикой
using System.Collections;
using System.Collections.Generic;
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
    public int countServedShoppers;         // текущее колво обслужанных клиентов



    //[Header("Мах число жизней замка")]
    //public int maxHealthCastle = 10;

    [HideInInspector]
    public int currentTimerGame;

    [Header("Ссыль SpawnerShoppers")]
    [SerializeField]
    public SpawnerShoppers spawnerShoppers;

    //[Header("Кол-во Spawn снарядов в начале игры")]
    //[SerializeField]
    //public int countBulletsStartGame;

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
    //[HideInInspector]
    public Transform[] PointsBuy;

    //[SerializeField]
    //[Header("Мах кол-во ботов")]
    //private int maxCountBots = 10;

    //[HideInInspector]
    public int currentLevel;   //   текущий уровень 

    [HideInInspector]
    public bool isPlayGame;

    //[HideInInspector]
    public StateGame stateGame;

    //[HideInInspector]
    public int currentHealthCastle; // текущее здоровье замка

    [HideInInspector]
    public int currentCountBots;   //  текущее кол-во ботов

    //[HideInInspector]
    /// <summary>
    /// текущее кол-во бабла
    /// </summary>
    public int currentMoney;  //  текущее кол-во бабла

    [HideInInspector]
    public int allMoney;      // всего денях

    [HideInInspector]
    public int currentIDSkin;   // текущий ID skin

    //[HideInInspector]
    //public int currentIDWeapon;   // текущий ID weapon

    [HideInInspector]
    public int upgradeDobleShootLevel;     //  // текущий Level DoubleShoot

    [HideInInspector]
    public int currentPriceDoubleShoot;    // цена прокачки DoubleShoot

   // [HideInInspector]
    public int upgradeSpeedHeroLevel;      //  // текущий Level SpeedHero

    [HideInInspector]
    public int currentPriceSpeedHero;     // цена прокачки SpeedHero


    void Awake()
    {
        Instance = this;
        //currentLevel = 1;
        PanelGame.SetActive(false);
        PanelWinGame.SetActive(false);
        PanelLoseGame.SetActive(false);
        // spawnerBullets.gameObject.SetActive(false);
        spawnerShoppers.gameObject.SetActive(false);
        PanelStartGame.gameObject.SetActive(true);

        currentLevel = LoadData("LevelNumber");          /// З А Г Р У З К А     Л Е В Е Л А /////////////////////////////////

        //maxHealthCastle = LoadData("MaxHealthCastle");

        if (currentLevel == 0)
        {
            currentLevel = 1;
        }

        //if (maxHealthCastle == 0)
        //{
        //    maxHealthCastle = SetRandomHealth(currentLevel);
        //    SaveData("MaxHealthCastle", maxHealthCastle);                            // сохраняем мах колво жизней на уровне
        //}


        //currentMoney = LoadData("Money");
        allMoney = LoadData("Money");
        currentIDSkin = LoadData("SavedIDSkin");
        //currentIDWeapon = LoadData("SavedIDWeapon");
        //PlayerPrefs.SetInt("SavedIDWeapon", currentIDWeapon);

        SetLoadScene(currentLevel);
    }


    void Start()
    {
        //currentCountBots = maxCountBots;
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

        //if (currentCountBots <= 0 && currentTimerGame <= 0)
        {
            stateGame = StateGame.WinGame;
        }
    }

    /// <summary>
    /// обновления игры
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
        //spawnerBullets.gameObject.SetActive(true);
        spawnerShoppers.gameObject.SetActive(true);
        PanelStartGame.SetActive(false);
        PanelGame.SetActive(true);
    }

    /// <summary>
    /// конец игры
    /// </summary>
    public void EndGame()
    {
        //spawnerBullets.gameObject.SetActive(false);
        spawnerShoppers.gameObject.SetActive(false);
        PanelGame.SetActive(false);
        SaveData("LevelNumber", currentLevel);                            // сохраняем номер level

        int saveMoney = currentMoney + allMoney;
        SaveData("Money", saveMoney);                                 // сохраняем колво денег
        StartCoroutine(ShowAnimationMoney());
        Debug.Log("End Game");
    }


    /// <summary>
    /// Победа
    /// </summary>
    void WinGame()
    {
        currentLevel++;
        currentMoney += GameSettings.Instance.countMoneyGame;

        //maxHealthCastle = SetRandomHealth(currentLevel);
        //SaveData("MaxHealthCastle", maxHealthCastle);                            // сохраняем мах колво жизней на уровне

        EndGame();
        Debug.Log("Win Game");

        PanelWinGame.SetActive(true);
    }


    /// <summary>
    /// Проигрыш
    /// </summary>
    void LoseGame()
    {
        EndGame();

        Debug.Log("Lose Game");
        PanelLoseGame.SetActive(true);
    }

    private IEnumerator ShowAnimationMoney()
    {
        float timerShowAnimationMoney = 0.1f;
        print("ShowAnimationMoney");
        while (currentMoney > 0)
        {
            currentMoney--;
            allMoney++;
            yield return new WaitForSeconds(timerShowAnimationMoney);  //WaitForEndOfFrame();
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

    //if (currentScene != SceneManager.GetActiveScene().buildIndex)
    //{
    //    SceneManager.LoadScene(currentScene);
    //}
    public void LoadScene(int currentScene)
    {


        int tempLoadScene = currentScene - 1;

        print(" currentScene " + currentScene);
        print(" currentLevel " + currentLevel);
        print(" SceneManager.sceneCountInBuildSettings " + (SceneManager.sceneCountInBuildSettings - 2));
        print(" tempLoadScene " + tempLoadScene);

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
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);                          // текущая сцена
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

    /// <summary>
    /// Увел или умень текущ кол-во денех
    /// </summary>
    /// <param name="money"></param>
    //public void SetCurrentMoney(int money) {
    //    currentMoney =+ money;
    //    currentMoney = currentMoney < 0 ? 0 : currentMoney; 
    //}

    public void SetCurrentMoney(int money)
    {
        currentMoney += money;
        currentMoney = currentMoney < 0 ? 0 : currentMoney;
    }

    public void SetCountServedShoppers() => countServedShoppers++;



}
