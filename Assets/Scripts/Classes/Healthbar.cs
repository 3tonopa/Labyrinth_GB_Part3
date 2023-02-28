using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Labyrinth
{

public sealed class Healthbar
{
    public GameObject hb;
    private Image hbImage;
    private GameObject onScreen;
    public Healthbar()
    {
            hb = new GameObject();
            onScreen = GameObject.Find("Canvas/OnScreen");
            hb.name = "Healthbar";
            hb.transform.SetParent(onScreen.transform);
            RectTransform _bTransform = hb.AddComponent(typeof(RectTransform)) as RectTransform;
            CanvasRenderer _bRender = hb.AddComponent(typeof(CanvasRenderer)) as CanvasRenderer;
            _bTransform.localPosition = new Vector2(-700, 500);
            hbImage = hb.AddComponent(typeof(Image)) as Image;
            hbImage.sprite = Resources.Load<Sprite>("_healthbar");
            hb.transform.localScale = new Vector3(5f, 0.5f, 0.0f);
            hbImage.color = Color.green;
            return;
    }
        public void SetValue(float val)
        {   
            float width =  Mathf.Lerp(0, 5f, val /100);
            float x = hb.transform.localPosition.x;
            hb.transform.localScale = new Vector3(width, 0.5f, 0.0f);
            if(val < 67 && val > 34) hbImage.color = Color.yellow;
            else if ( val < 34) hbImage.color = Color.red;
            else hbImage.color = Color.green;
        }
}
}