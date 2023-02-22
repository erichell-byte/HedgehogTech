using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class SpriteStorage : MonoBehaviour
    {
        private List<Sprite> emotionsSprites =  new List<Sprite>();
        private List<Sprite> clothesSprites = new List<Sprite>();
        private List<Sprite> hairSprites = new List<Sprite>();

        private void Start()
        {
            LoadSpritesFromAssetBundle();
        }

        private void LoadSpritesFromAssetBundle()
        {
            AssetBundle faceBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/face_bundle");
            string[] faceSpriteNames = faceBundle.GetAllAssetNames();
            foreach (string spriteName in faceSpriteNames)
            {
                Sprite sprite = faceBundle.LoadAsset<Sprite>(spriteName);
                emotionsSprites.Add(sprite);
            }

            faceBundle.Unload(false);
            
            AssetBundle clothesBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/clothes_bundle");
            string[] clothesSpriteNames = clothesBundle.GetAllAssetNames();
            foreach (string spriteName in clothesSpriteNames)
            {
                Sprite sprite = clothesBundle.LoadAsset<Sprite>(spriteName);
                clothesSprites.Add(sprite);
            }

            clothesBundle.Unload(false);
            
            AssetBundle hairBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/hair_bundle");
            string[] hairSpriteNames = hairBundle.GetAllAssetNames();
            foreach (string spriteName in hairSpriteNames)
            {
                Sprite sprite = hairBundle.LoadAsset<Sprite>(spriteName);
                hairSprites.Add(sprite);
            }

            hairBundle.Unload(false);
        }

        public List<Sprite> GiveListByEnum(CharacterLayers layer)
        {
            switch (layer)
            {
                case CharacterLayers.Clothes:
                    return clothesSprites;
                case CharacterLayers.Emotions:
                    return emotionsSprites;
                case CharacterLayers.Hair:
                    return hairSprites;
            }

            throw new Exception($"Havent list of sprites for layer {layer}");
        }
    }
}