using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class Game : ScreenObserver
    {
        #region Fields
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _returnToMenuWindow;
        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.Game;
        #endregion

        #region Overridden Methods
        public override void Activate()
        {
            _returnToMenuWindow.onClick.AddListener(OnClickMenu);
            SceneManager.activeSceneChanged += OnActiveSceneChange;

            _gameOverWindow.SetActive(false);

            base.Activate();
            _returnToMenuWindow.interactable = true;
        }

        public override void Deactivate()
        {
            _returnToMenuWindow.onClick.RemoveListener(OnClickMenu);
            SceneManager.activeSceneChanged -= OnActiveSceneChange;

            _gameOverWindow.SetActive(false);

            base.Deactivate();
            _returnToMenuWindow.interactable = true;
        }
        #endregion

        #region Event Handlers
        private void OnClickMenu()
        {
            SceneManager.LoadScene(GameScenes.MENU);

            _returnToMenuWindow.interactable = false;
        }

        private void OnActiveSceneChange(Scene current, Scene next) => UICore.OpenScreen(UIScreen.Main);
        #endregion

        #region Public API
        public void SetScore(int score) => _score.text = score.ToString();

        public void ShowWindowOnGameOver()
        {
            _gameOverWindow.SetActive(true);
        }
        #endregion
    }
}