using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UserInterface
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
#endif
    public class Main : ScreenObserver
    {
        #region Editor Fields
        [SerializeField] private Button _startGame;
        #endregion

        #region Properties
        public override UIScreen Screen => UIScreen.Main;
        #endregion

        #region Overridden Methods
        public override void Activate()
        {
            _startGame.onClick.AddListener(OnClickStartGame);
            SceneManager.activeSceneChanged += OnActiveSceneChange;

            base.Activate();
            _startGame.interactable = true;
        }

        public override void Deactivate()
        {
            _startGame.onClick.RemoveListener(OnClickStartGame);
            SceneManager.activeSceneChanged -= OnActiveSceneChange;

            base.Deactivate();
            _startGame.interactable = true;
        }
        #endregion

        #region Event Handlers
        private void OnClickStartGame()
        {
            SceneManager.LoadScene(GameScenes.GAME);

            _startGame.interactable = false;
        }

        private void OnActiveSceneChange(Scene current, Scene next) => UICore.OpenScreen(UIScreen.Game);
        #endregion
    }
}