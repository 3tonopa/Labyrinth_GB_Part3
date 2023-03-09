using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{
    public sealed class ScoreInd
    {
        public GameObject gObj;
        private GameObject onScreen;
        public Text _text;
        public ScoreInd(Font font)
        {
            onScreen = GameObject.Find("Canvas/OnScreen");
            gObj = new GameObject();
            gObj.name = "Score";
            gObj.transform.SetParent(onScreen.transform);
            RectTransform _bTransform = gObj.AddComponent(typeof(RectTransform)) as RectTransform;
            CanvasRenderer cr = gObj.AddComponent(typeof(CanvasRenderer)) as CanvasRenderer;

            _text = gObj.AddComponent(typeof(Text)) as Text;
            _bTransform.localPosition = new Vector2(435, 500);
            _bTransform.sizeDelta = new Vector2(100, 100);
            _text.color = Color.yellow;
            _text.font = font;
            _text.fontSize = 72;
            _text.resizeTextForBestFit = true;
            _text.alignment = TextAnchor.MiddleCenter;
            return;
        }
    }
}