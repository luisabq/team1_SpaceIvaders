using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    public int enemyCount;
    public string sceneToLoad;
    public float winPause = 2f;

    public GameObject winText;
    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        winText.SetActive(false);
    }

    public void SubtractOne()
    {
        enemyCount--;
        
        if (enemyCount <= 0)
        {
            StartCoroutine(Win());
        }
    }
    
    IEnumerator Win()
    {
        winText.SetActive(true);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(winPause);

        Time.timeScale = 1f;
        winText.SetActive(false);

        SceneManager.LoadScene(sceneToLoad);
    }
}
