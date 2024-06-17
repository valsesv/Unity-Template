using UnityEngine;
using valsesv._Project.Scripts.Resources;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameStatesManagement
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private GameInstaller _gameInstaller;
        [Inject] private GameStateController _gameStateController;

        private void Awake()
        {
            _gameInstaller.InitManagers();
            _gameStateController.SetState(GameState.Boot);
        }
    }
}