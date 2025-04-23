using UnityEngine;

namespace Sources.BasicLogic._2DLogic
{
    public class EnemyCharacter : MonoBehaviour
    {
        [SerializeField] private float _agrDistance;
        [SerializeField] private float _attackDistance;
        [SerializeField] private CharacterMovement _characterMovement;
        
        private PlayerCharacter _playerCharacter;
        private bool _isAgred;

        public void Initialize(PlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        private void Update()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _playerCharacter.transform.position);
            
            if (_isAgred == false)
            {
                if (distanceToPlayer <= _agrDistance)
                    _isAgred = true;
            }
            else
            {
                if(distanceToPlayer > _attackDistance)
                    _characterMovement.Move((_playerCharacter.transform.position - transform.position).normalized.x);
            }
        }
    }
}