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

            if (type == "Restart")
            {
                _bTransform.localPosition = new Vector2(840, 500);
                _bTransform.sizeDelta = new Vector2(150, 50);
            }

            if (type == "Pause")
            {
                _bTransform.localPosition = new Vector2(840, 420);
                _bTransform.sizeDelta = new Vector2(150, 50);
            }
             if (type == "Save")
            {
                _bTransform.localPosition = new Vector2(840, 200);
                _bTransform.sizeDelta = new Vector2(150, 40);
            }
             if (type == "Load")
            {
                _bTransform.localPosition = new Vector2(840, 120);
                _bTransform.sizeDelta = new Vector2(150, 40);
            }
            return;
        }
    }
}

