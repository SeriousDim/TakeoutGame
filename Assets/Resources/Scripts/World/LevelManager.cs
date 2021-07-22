using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Takeout.DataWrappers;

/* Содержит логику получения звезд на уровне и работы с меню паузы
 * Наследуем этот класс к каждому LevelXManager.cs, где
 * Х - номер/название уровня. В наследуемом скрипте пишем логику
 * для активности(звезд)
 */
public class LevelManager : MonoBehaviour
{
    public int maxStars;
    public GameObject rubbish;
    public GameObject pauseMenu;
    public GameObject endOfLevel;
    public GameObject player;

    [HideInInspector]
    public bool[] stars;
    [HideInInspector]
    public int gotStars = 0;
    [HideInInspector]
    public TextMeshProUGUI totalText;

    // обязательно надо давать значения этим перемнным в каждом наследуемом классе
    [HideInInspector]
    public Descriptions[] desc;
    [HideInInspector]
    public string thisLevelName;

    private Image[] starImages;
    private Sprite givenStarSprite;

    private GameObject[] endStarsObj;

    private bool finished = false;

    private PointsCounter pointsCounter;
    private InventorySelector inventorySelector;

    private const string MAIN_MENU = "MainMenu";

    public virtual void ConfirmCollectionRubbish()
    {
        Debug.Log("LevelManager.ConfirmCollectionRubbish: col rubbish collected");
    }
    
    public void Start()
    {
        stars = new bool[maxStars];
        starImages = new Image[maxStars];

        givenStarSprite = Resources.Load<Sprite>("Sprites/GUI/star_got");

        // создаем звезды в меню паузы
        Transform starsObj = pauseMenu.transform.Find("Stars");
        GameObject star = starsObj.Find("Star1").gameObject;
        starImages[0] = star.GetComponent<Image>();

        for (var i = 0; i < maxStars - 1; i++)
        {
            GameObject newStar = Instantiate(star);
            starImages[i + 1] = newStar.GetComponent<Image>();
            newStar.transform.parent = starsObj;
        }

        totalText = endOfLevel.transform.Find("Panel").Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        desc = new Descriptions[maxStars];

        pointsCounter = player.GetComponent<PointsCounter>();
        inventorySelector = player.GetComponent<InventorySelector>();
    }

    public void Update()
    {
        if (rubbish.transform.childCount == 0 && !finished)
        {
            FinishLevel();
        }
    }

    public void GiveStar(int ind)
    {
        stars[ind] = true;
        starImages[gotStars].sprite = givenStarSprite;
        gotStars++;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void SaveData()
    {
        // сохраняем данные уровня
        LevelData oldData = DataSingleton.levelData[thisLevelName];
        LevelData lvlData = new LevelData(maxStars, thisLevelName, stars, desc);

        if (oldData == null)
        {
            DataSingleton.levelData[thisLevelName] = lvlData;
            Debug.Log(DataSingleton.levelData[thisLevelName].ToString());
            return;
        }

        var flag = false;

        for (var i = 0; i < stars.Length; i++)
        {
            if (!oldData.stars[i] && stars[i])
            {
                flag = true;
                break;
            }
        }

        if (flag)
        {
            DataSingleton.levelData[thisLevelName] = lvlData;
            Debug.Log(DataSingleton.levelData[thisLevelName].ToString());
        }

        // TODO: если текущая версия выше, чем в файле - обновить все равно данные

        // сохраняем данные игрока
        DataSingleton.playerData.likecoins += pointsCounter.points;
        Debug.Log("PlayerData.likecoins = " + DataSingleton.playerData.likecoins);

        flag = true;

        for (var i = 0; i < inventorySelector.COLLECTION_INVENTORY_SIZE; i++)
        {
            if (inventorySelector.colInventory[i] == null)
            {
                flag = false;
                break;
            }
        }

        if (flag)
        {
            for (var i = 0; i < inventorySelector.COLLECTION_INVENTORY_SIZE; i++)
            {
                var item = inventorySelector.colInventory[i];

                if (!DataSingleton.playerData.colRubbish.ContainsKey(item.name))
                {
                    DataSingleton.playerData.colRubbish.Add(item.name, item.GetComponent<PropCollision>().colRubObj);
                }
            }
            Debug.Log(DataSingleton.playerData.ToString());
        }

        // сохраняем данные в файл
        DataSingleton.SaveAll();
    }

    public virtual void FinishLevel()
    {
        finished = true;
        Time.timeScale = 0;

        // создаем звезды на экране конца уровня
        Transform starsObj = endOfLevel.transform.Find("Panel").Find("Stars");
        endStarsObj = new GameObject[gotStars];

        GameObject star = starsObj.Find("Star1").gameObject;
        endStarsObj[0] = star;
        for (var i = 0; i < gotStars - 1; i++)
        {
            GameObject newStar = Instantiate(star);
            endStarsObj[i + 1] = newStar;
            newStar.transform.parent = starsObj;
        }

        endOfLevel.SetActive(true);
        SaveData();

        /* TODO: animate stars */
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
}
