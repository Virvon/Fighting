using Assets.Sources.Services.InputService;
using UnityEngine;

namespace Sources.BasicLogic._2DLogic
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private Animator _animator;
        
        private IInputService _inputService;

        private bool _isMoved;

        private void Start()
        {
            _inputService.Moved += OnMoved;
            _inputService.Stopped += OnStopped;
            _inputService.Attacked += OnAttacked;
        }

        private void OnDestroy()
        {
            _inputService.Moved -= OnMoved;
            _inputService.Stopped -= OnStopped;
            _inputService.Attacked -= OnAttacked;
        }

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnMoved(Vector2 direction)
        {
            _movement.Move(direction.x);

            if (_isMoved == false)
            {
                _isMoved = true;
                _animator.SetBool(AnimationsPath.IsMoved, true);
            }
        }

        private void OnStopped()
        {
            _isMoved = false;
            _animator.SetBool(AnimationsPath.IsMoved, false);
        }

        private void OnAttacked()
        {
            _animator.SetTrigger(AnimationsPath.Attack);
        }
    }
}