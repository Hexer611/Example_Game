using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    [SerializeField]
    GameObject remaining_enemy_text;
    [SerializeField]
    GameObject start_button;
    [SerializeField]
    Player player_script;
    [SerializeField]
    Enemy_Spawner enemy_spawner_script;
    [SerializeField]
    GameObject[] win_lose_screens; // 0-winscreen, 1-losescreen
    [SerializeField]
    GameObject blackbackground;

    public void start_click()
    {
        start_button.SetActive(false);
        blackbackground.SetActive(false);
        remaining_enemy_text.SetActive(true);
        Time.timeScale = 1;
        player_script.enabled = true;
        enemy_spawner_script.enabled = true;
    }
    public void win_screen()
    {
        win_lose_screens[0].SetActive(true);
        blackbackground.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(Sceneload());
    }
    public void lose_screen()
    {
        win_lose_screens[1].SetActive(true);
        blackbackground.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(Sceneload());
    }
    IEnumerator Sceneload()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
