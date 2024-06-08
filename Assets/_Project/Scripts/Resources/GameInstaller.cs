using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using valsesv._Project.Scripts.Managers.ScenesManagement;
using valsesv._Project.Scripts.UI;
using Zenject;

namespace valsesv._Project.Scripts.Resources
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private SceneController sceneController;
        [Space(10)]
        [SerializeField] private UiProjectManager gameUiProjectManager;

        public override void InstallBindings()
        {
            BindManagers();
            InitManagers();

            gameStateController.SetState(GameState.Menu);
        }

        private void BindManagers()
        {
            Container.Bind<SceneController>().FromInstance(sceneController).AsSingle();
            Container.Bind<UiProjectManager>().FromInstance(gameUiProjectManager).AsSingle();

            Container.Bind<GameStateController>().FromInstance(gameStateController).AsSingle();
        }

        private void InitManagers()
        {
            gameStateController.Init();
            sceneController.Init();
            gameUiProjectManager.Init();
        }
    }
}