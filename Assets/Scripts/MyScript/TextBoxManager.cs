using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	const int SPECIES_OF_CHARACTER = 3;//キャラの数
	const int KIND_OF_SPEECH = 3;//テキストのパターン数
	const int TAP_BODY = 0;
	const int FLICK_HEAD = 1;
	const int TAP_HEAD = 2;
	const int FLICK_BODY = 3;


	static string[,,] Speech = new string[SPECIES_OF_CHARACTER, 4, KIND_OF_SPEECH];

	static Image panel;
	static Text uiText;
	static bool TextVisible = false;


	float time = 0;
	public float WaitTime = 2.5f;


	int RUBI_NO = 0;
	int SURVAL_NO = 1;
	int SIZUKU_NO = 2;



	// Use this for initialization
	void Start () {
		panel = GameObject.Find ("Panel").GetComponent<Image> (); panel.enabled = false;
		uiText = GameObject.Find ("Text").GetComponent<Text> ();  uiText.enabled = false;

		setText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TextVisible) {
				if (time > WaitTime) {
				uiText.enabled = false;
				panel.enabled = false;
				time = 0;
				TextVisible = false;
			}
			time += Time.deltaTime;
		}
	}


	public static void StartText (string Group, int no) {
		int group = new int();
		group = -1;
		switch (Group) {
		case "tap_body":
			group = TAP_BODY;
			break;

		case "flick_head":
			group = FLICK_HEAD;
			break;

		case "tap_head":
			group = TAP_HEAD;
			break;

		case "flick_body":
			group = FLICK_HEAD;
			break;

		}

		if (group == -1) return;

		if (Speech [LAppLive2DManager.sceneIndex, group, no] != null) {
			uiText.enabled = true;
			panel.enabled = true;
			uiText.text = Speech [LAppLive2DManager.sceneIndex, group, no];
			TextVisible = true;
		}
	}


	void setText () {

		Speech [RUBI_NO, TAP_BODY, 0] = "tap_budy_0";
		Speech [RUBI_NO, FLICK_HEAD, 0] = "なにぃ～～？";
		Speech [RUBI_NO, TAP_HEAD, 0] = "わああ～～～～";

		Speech [SURVAL_NO, TAP_BODY, 0] = "びっくりしたー";
		Speech [SURVAL_NO, TAP_HEAD, 0] = "たーのしー";
	}
}
