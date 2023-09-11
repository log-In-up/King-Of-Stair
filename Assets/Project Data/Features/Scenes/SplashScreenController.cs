using UnityEngine;
using UnityEngine.SceneManagement;
using UserInterface;

namespace SplashScreen
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public sealed class SplashScreenController : MonoBehaviour
    {
        #region Editor fields
        [SerializeField] private UICore _uiCore = null;
        #endregion

        #region Fields
        private AsyncOperation _loadMenuScene = null;
        #endregion

        #region MonoBehaiour API
        private void Awake()
        {
            _loadMenuScene = SceneManager.LoadSceneAsync((int)GameScenes.Menu);
            _loadMenuScene.allowSceneActivation = false;
        }

        private void Start() => _uiCore.OpenScreen(UIScreen.SplashScreen);

        private void OnEnable() => _loadMenuScene.completed += OnCompletionLoadMenuScene;

        private void OnDisable() => _loadMenuScene.completed += OnCompletionLoadMenuScene;
        #endregion

        #region Event Handlers
        private void OnCompletionLoadMenuScene(AsyncOperation obj)
        {
            _uiCore.OpenScreen(UIScreen.Main);

            _loadMenuScene.allowSceneActivation = true;
        }
        #endregion
    }
}
