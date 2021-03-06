using UnityEngine;

[ExecuteInEditMode]
public class MyGameController : MonoBehaviour {
    private float lastX = -1;
    private float lastY = -1;

	Renderer background1;
	Renderer background2;

	// Use this for initialization
	void Awake () {
		background1 = GameObject.Find ("background").GetComponent<Renderer> ();
		background2 = GameObject.Find ("background_kemono").GetComponent<Renderer> ();


        var camera=GameObject.Find("Main Camera");
        if (camera!=null)
	    {
            if ( camera.GetComponent<Camera>().orthographic)
            {
                LAppLive2DManager.Instance.SetTouchMode2D(true);

            }
            else
            {
                Debug.Log("\"Main Camera\" Projection : Perspective");

                LAppLive2DManager.Instance.SetTouchMode2D(false);

            }

        }

	}
	
	// Update is called once per frame
	void Update () {
		//Spaceキー、右クリックでキャラ交代
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(1)) {
			LAppLive2DManager.Instance.ChangeModel ();
			if (LAppLive2DManager.sceneIndex == 1) {
				background1.enabled = false;
				background2.enabled = true;
			} else {
				background1.enabled = true;
				background2.enabled = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) Application.Quit ();

        // タッチイベントの取得
        if (Input.GetMouseButtonDown(0))
        {
            lastX = Input.mousePosition.x;
            lastY = Input.mousePosition.y;
            LAppLive2DManager.Instance.TouchesBegan(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            if (lastX == Input.mousePosition.x && lastY == Input.mousePosition.y)
            {
                return;
            }
            lastX = Input.mousePosition.x;
            lastY = Input.mousePosition.y;
            LAppLive2DManager.Instance.TouchesMoved(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastX = -1;
            lastY = -1;
            LAppLive2DManager.Instance.TouchesEnded(Input.mousePosition);
        }

        // Androidのバックボタンで終了
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                return;
            }
        }

		//ESCで終了
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}
}