using System;
using UnityEngine;

namespace Sources.BasicLogic._2DLogic
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private bool _isFlipped;

        private void Start()
        {
            SetFlip(_isFlipped);
        }

        public void Move(float horizontalDirection)
        {
            transform.position += new Vector3(_speed * horizontalDirection * Time.deltaTime, 0, 0);
            
            if(horizontalDirection > 0 && _isFlipped == false)
                SetFlip(true);
            else if(horizontalDirection < 0 && _isFlipped)
                SetFlip(false);
        }

        private void SetFlip(bool isFlipped)
        {
            _isFlipped = isFlipped;

            transform.localScale = new Vector3(_isFlipped ? -1 : 1, 1, 1);
        }
    }
}