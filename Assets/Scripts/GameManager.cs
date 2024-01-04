using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private const int MAIN_MENU_SCENE = 0;
        private const int GAME_SCENE = 1;
        private const int TUTORIAL_SCENE = 2;
        private const int GAME_OVER_SCENE = 3;

        private static GameManager _instance;
        
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = "GameManager (Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(GAME_SCENE);
        }
        
        public void LoadTutorialScene()
        {
            SceneManager.LoadScene(TUTORIAL_SCENE);
        }
        
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE);
        }
        
        public void LoadGameOverScene()
        {
            SceneManager.LoadScene(GAME_OVER_SCENE);
        }
    }
}