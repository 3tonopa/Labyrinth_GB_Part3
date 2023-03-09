using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{
    public sealed class Buttons
    {
        public GameObject gObj;
        private GameObject onScreen;
        public Buttons(string type)
        {
            onScreen = GameObject.Find("Canvas/OnScreen");
            gObj = new GameObject();
            gObj.name = type;
            gObj.transform.SetParent(onScreen.transform);
            RectTransform _bTransform = gObj.AddComponent(typeof(RectTransform)) as RectTransform;
            CanvasRenderer _bRender = gObj.AddComponent(typeof(CanvasRenderer)) as CanvasRenderer;
            Image _bImage = gObj.AddComponent(typeof(Image)) as Image;
            _bImage.sprite = Resources.Load<Sprite>($"_{type.ToLower()}");
            Button _bButton = gObj.AddComponent(typeof(Button)) as Button;
            gObj.tag = type;

            if (type == "Quit")
            {
                _bTransform.localPosition = new Vector2(920, 500);
                _bTransform.sizeDelta = new Vector2(50, 50);
            }

            if (type == "Restart")
            {
                _bTransform.localPosition = new Vector2(800, 500);
                _bTransform.sizeDelta = new Vector2(150, 50);
            }

            if (type == "Pause")
            {
                _bTransform.localPosition = new Vector2(650, 500);
                _bTransform.sizeDelta = new Vector2(150, 50);
            }
             if (type == "Save")
            {
                _bTransform.localPosition = new Vector2(840, 260);
                _bTransform.sizeDelta = new Vector2(150, 40);
            }
             if (type == "Load")
            {
                _bTransform.localPosition = new Vector2(840, 180);
                _bTransform.sizeDelta = new Vector2(150, 40);
            }
            return;
        }
    }
}

