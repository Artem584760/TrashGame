using System;
using Hints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hints
{
    public class Hint : MonoBehaviour
    {
        private Transform _playerTransform;

        private Transform _pointTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;

            SetHintVisible(false);
        }

        private void Update()
        {
            Vector3 directionToPlayer = _playerTransform.position - transform.position;
            directionToPlayer.y = 0;
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }


        public void SetHintVisible(bool visible)
        {
            GetComponent<Image>().enabled = visible;
            GetComponentInChildren<TextMeshProUGUI>().enabled = visible;
            
            if (visible)
            {
                transform.position = _pointTransform.position;
            }
        }

        public void SetHintPoint(Transform newPoint)
        {
            _pointTransform = newPoint;
        }
    }
}    
