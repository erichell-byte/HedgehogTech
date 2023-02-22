using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class SpriteChanger : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer replaceableSprite;
        
        [Space]
        [SerializeField] 
        private SpriteIndexChanger spriteIndexChanger;

        [SerializeField]
        private SpriteStorage storage;

        [SerializeField]
        private CharacterAppearController appearController;

        [SerializeField] 
        private CharacterLayers layer;

        private int _currentIndex;
        
        private List<Sprite> _replacementSprites;
        private void Start()
        {
            _replacementSprites = storage.GiveListByEnum(layer);
        }

        private void OnEnable()
        {
            spriteIndexChanger.OnSpriteIndexChanged += OnIndexChanged;
            appearController.CharacterIsOutOffScreen += ChangeSprite;
        }

        private void OnDisable()
        {
            spriteIndexChanger.OnSpriteIndexChanged -= OnIndexChanged;
            appearController.CharacterIsOutOffScreen -= ChangeSprite;
        }

        private void OnIndexChanged(int index)
        {
            if (appearController.isMoving)
                return;
            if (_currentIndex + index >= _replacementSprites.Count)
                _currentIndex = 0;
            else if (_currentIndex + index < 0)
                _currentIndex = _replacementSprites.Count - 1;
            else
                _currentIndex += index;
            
            appearController.StartMoveOutOfScreen(layer);
        }

        private void ChangeSprite(CharacterLayers layer)
        {
            if (this.layer == layer)
                replaceableSprite.sprite = _replacementSprites[_currentIndex];
        }
    }
}