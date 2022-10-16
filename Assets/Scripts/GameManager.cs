using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//God forgive me but im doing UI in game manager
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip transition;
    public enum GameState
    {
        MainMenu,
        StageOne,
        Boss
    }
    
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public GameState state;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator LoadScene(float time, string sceneName)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && state == GameState.StageOne)
        {
            PlayerInteractions.Instance.PlaySong(transition);
            state = GameState.Boss;
            PlayerInteractions.Instance.screenTransition.FadeInOut(5.0f, () => SceneManager.LoadScene("SampleScene"));
        }
        
    }
}
