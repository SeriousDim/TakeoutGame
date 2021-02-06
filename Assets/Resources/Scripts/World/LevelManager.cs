using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Содержит логику получения звезд на уровне и работы с меню паузы
 * Наследуем этот класс к каждому LevelXManager.cs, где
 * Х - номер/название уровня. В наследуемом скрипте пишем логику
 * для активности(звезд)
 */
public class LevelManager : MonoBehaviour
{
    public int maxStars;
    public GameObject pauseMenu;

    [HideInInspector]
    public bool[] stars;
    public int gotStars = 0;

    private Image[] starImages;
    private Sprite givenStarSprite;

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

        Transform starsObj = pauseMenu.transform.Find("Stars");
        GameObject star = starsObj.Find("Star1").gameObject;
        starImages[0] = star.GetComponent<Image>();

        for (var i = 0; i < maxStars - 1; i++)
        {
            GameObject newStar = Instantiate(star);
            starImages[i + 1] = newStar.GetComponent<Image>();
            newStar.transform.parent = starsObj;
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

    public void QuitLevel()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
}
