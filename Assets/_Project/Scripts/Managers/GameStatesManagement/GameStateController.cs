using System;
using UnityEngine;
using UnityEngine.Serialization;
using valsesv._Project.Scripts.Interfaces;
using valsesv._Project.Scripts.Managers.ScenesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameStatesManagement
{
    public class GameStateController : MonoBehaviour, IManager
    {
        [SerializeField] private SceneController sceneController;

        private GameState _state;

        public event Action<GameState> OnStateChangedEvent;

        public event Action OnMenuStateEvent;
        public event Action OnGameStartedEvent;
        public event Action OnGameEndedEvent;
        public event Action OnWinEvent;
        public event Action OnLoseEvent;

        public bool IsPlaying { get; private set; }

        public GameState State
        {
            get => _state;
            private set
            {
                if (value == _state)
                {
                    return;
                }
                _state = value;
                switch(_state)
                {
                    case GameState.Menu:
                        SetMenuState();
                        break;
                    case GameState.Game:
                        TryStartGame();
                        break;
                    case GameState.Win:
                        TryWin();
                        break;
                    case GameState.Lose:
                        TryLose();
                        break;
                    case GameState.Boot:
                        LoadBootScene();
                        break;
                    case GameState.None:
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                OnStateChangedEvent?.Invoke(_state);
            }
        }

        public void Init()
        {

        }

        public void SetState(GameState gameState)
        {
            State = gameState;
        }

        private void LoadBootScene()
        {
            SetState(GameState.Menu);
        }

        private void SetMenuState()
        {
            sceneController.LoadScene(SceneType.Menu);
            IsPlaying = false;
            OnMenuStateEvent?.Invoke();
        }

        private void TryStartGame()
        {
            if (IsPlaying) return;

            IsPlaying = true;
            OnGameStartedEvent?.Invoke();
        }

        private void TryWin()
        {
            if (IsPlaying == false) return;
            EndGame();

            OnWinEvent?.Invoke();
        }


        private void TryLose()
        {
            if (IsPlaying == false) return;
            EndGame();

            OnLoseEvent?.Invoke();
        }

        private void EndGame()
        {
            IsPlaying = false;
            OnGameEndedEvent?.Invoke();
        }
    }
}