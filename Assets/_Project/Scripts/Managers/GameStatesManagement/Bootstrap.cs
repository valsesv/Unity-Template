using UnityEngine;
using valsesv._Project.Scripts.Managers.ScenesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Managers.GameStatesManagement
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private SceneController _sceneController;

        private void Awake()
        {
            _sceneController.LoadScene(SceneType.Menu);
        }
    }
}