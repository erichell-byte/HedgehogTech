using System;
using UnityEngine;

namespace TestProject
{
    public class SpriteIndexChanger : MonoBehaviour
    {
        public Action<int> OnSpriteIndexChanged;

        public void NextIndex()
        {
            OnSpriteIndexChanged?.Invoke(1);
        }

        public void PrevIndex()
        {
            OnSpriteIndexChanged?.Invoke(-1);
        }
    }
}
