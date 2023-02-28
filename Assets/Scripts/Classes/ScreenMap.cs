using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{
    public sealed class ScreenMap
    {
        public GameObject map;
        public GameObject ex;
        private Image mapImage;
        private GameObject onScreen;
        private RectTransform _plTransform;

        public ScreenMap()
        {
            map = new GameObject();
            onScreen = GameObject.Find("Canvas/OnScreen");
            map.name = "Map";
            map.transform.SetParent(onScreen.transform);

            RectTransform _bTransform = map.AddComponent(typeof(RectTransform)) as RectTransform;
            CanvasRenderer _bRender = map.AddComponent(typeof(CanvasRenderer)) as CanvasRenderer;
            _bTransform.localPosition = new Vector2(-800, 380);
            mapImage = map.AddComponent(typeof(Image)) as Image;
            mapImage.sprite = Resources.Load<Sprite>("_map");
            _bTransform.sizeDelta = new Vector2(300, 300);

            GameObject pl = new GameObject();
            pl.name = "PlayerIcon";
            pl.transform.SetParent(map.transform);
            _plTransform = pl.AddComponent(typeof(RectTransform)) as RectTransform;
            CanvasRenderer _plRender = pl.AddComponent(typeof(CanvasRenderer)) as CanvasRenderer;
            _plTransform.localPosition = new Vector2(-131, -131);
            Image plImage = pl.AddComponent(typeof(Image)) as Image;
            plImage.sprite = Resources.Load<Sprite>("_playerIcon");
            _plTransform.sizeDelta = new Vector2(15, 15);
            
            ex = new GameObject();
            GameObject exitObject = GameObject.Find("Exit");
            ex.name = "ExitIcon";
            ex.transform.SetParent(map.transform);
            RectTransform _exTransform = ex.AddComponent(typeof(RectTransform)) as RectTransform;
            CanvasRenderer _exRender = ex.AddComponent(typeof(CanvasRenderer)) as CanvasRenderer;
            float x = Mathf.Lerp(-131, 132, exitObject.transform.position.x / 44);
            float y = Mathf.Lerp(-145, 145, exitObject.transform.position.z / 44);
            if (_exTransform != null) _exTransform.localPosition = new Vector2(x, y);
            Image exImage = ex.AddComponent(typeof(Image)) as Image;
            exImage.sprite = Resources.Load<Sprite>("_exitIcon");
            _exTransform.sizeDelta = new Vector2(15, 15);
            
            ShowMap(false, 0);
            return;
        }
        public void SetPosition(Vector3 pos)
        {
            float x = Mathf.Lerp(-131, 132, pos.x / 44);
            float y = Mathf.Lerp(-145, 145, pos.z / 44);
            if (_plTransform != null) _plTransform.localPosition = new Vector2(x, y);
        }

        public void ShowMap(bool act, float m)
        {
            if(m == 1) ex.SetActive(true);
            else ex.SetActive(false);
            map.SetActive(act);
        }
    }
}