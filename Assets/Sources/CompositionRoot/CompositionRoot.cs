using Assets.Sources.Services.InputService;
using Assets.Sources.Services.SceneManagment;
using Sources.Infrastructure.ServiceLocator;
using UnityEngine;

namespace Sources.CompositionRoot
{
    public class CompositionRoot : MonoBehaviour
    {
        private const string NextScene = "2DGameplayScene";

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new DesktopInputService();
            ServiceLocator.Register(_inputService);

            SceneLoader sceneLoader = new();
            ServiceLocator.Register(sceneLoader);

            sceneLoader.Load(NextScene);

            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _inputService.Tick();
        }
    }
}