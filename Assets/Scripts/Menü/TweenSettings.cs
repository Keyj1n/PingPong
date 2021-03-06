﻿using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class TweenSettings : MonoBehaviour {

	public Transform Menü;
	public Vector3 MenüPos;
	private Tweener SettingsTween;
	public GameObject Icon;
	private string OldIcon;
	private int State;
	// Use this for initialization
	void Start () {
	}

	void OnClick(){
		if( Time.timeSinceLevelLoad> 0.1f ){
			if( State == 0 ){
				SettingsTween = HOTween.To(Menü, 0.5f, new TweenParms().AutoKill(false)
				                           .Prop("position",MenüPos, true) // Position tween (set as relative)
				                           .Ease(EaseType.EaseInOutQuad) // Ease
				                           );
				SettingsTween.Pause ();
				TweenSlider.ShowMenue = name;
				SettingsTween.PlayForward ();
				OldIcon = Icon.GetComponent<UISprite>().spriteName;
				Icon.GetComponent<UISprite>().spriteName = "ArrowBack";
				Icon.GetComponent<UIButton>().normalSprite = "ArrowBack";
				Icon.transform.localScale = Icon.transform.localScale/1.2f;
				transform.Rotate(0,0,-90);
				Menü.GetComponent<AudioSource>().Play();
				State = 1;
			}else if (State == 1){
				TweenSlider.ShowMenue = null;
				SettingsTween.PlayBackwards ();
				Icon.GetComponent<UISprite>().spriteName = OldIcon;
				Icon.GetComponent<UIButton>().normalSprite = OldIcon;
				Icon.transform.localScale = Icon.transform.localScale*1.2f;
				transform.Rotate(0,0,90);
				Menü.GetComponent<AudioSource>().Play();
				State = 0;
			}
		}
	}
}
