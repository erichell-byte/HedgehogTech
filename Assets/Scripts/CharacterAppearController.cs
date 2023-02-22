using System;
using System.Collections;
using UnityEngine;

namespace TestProject
{
    public class CharacterAppearController : MonoBehaviour
    {
        public bool isMoving;
        
        public Action<CharacterLayers> CharacterIsOutOffScreen;
        
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Camera mainCamera;
        
        private float _leftScreenBorderX;
        
        private void Start()
        {
            _leftScreenBorderX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x;
        }

        public void StartMoveOutOfScreen(CharacterLayers layer)
        {
            StartCoroutine(MoveOutOfScreen(layer));
        }

        private IEnumerator MoveOutOfScreen(CharacterLayers layer)
        {
            isMoving = true;
            
            Vector3 targetPosition = new Vector3(_leftScreenBorderX, transform.position.y, transform.position.z);
    
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            
            transform.position = new Vector3(-_leftScreenBorderX, transform.position.y, transform.position.z);
    
            CharacterIsOutOffScreen?.Invoke(layer);
            
            StartCoroutine(Reappear());
        }
        
        private IEnumerator Reappear()
        {
            Vector3 targetPosition = new Vector3(0, transform.position.y, transform.position.z);
            
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            
            isMoving = false;
        }
    }
}