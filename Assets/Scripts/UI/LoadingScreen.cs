using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingScreen : Menu
    {
        public static LoadingScreen Instance;

        protected override void Awake()
        {
            base.Awake();
            
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }
        
        protected void Start()
        {
            SetEnabled(true);
            FadeOut();
        }

        public void ReloadScene() 
            => ChangeScene(SceneManager.GetActiveScene().name);
        
        public void ChangeScene(string sceneName)
        {
            FadeIn(() => SceneManager.LoadScene(sceneName));
        }
    }
}