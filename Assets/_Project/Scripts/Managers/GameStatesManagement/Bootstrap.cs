using UnityEngine;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameStatesManagement
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private GameStateController _gameStateController;

        private void Awake()
        {
            _gameStateController.SetState(GameState.Boot);
        }
    }
}