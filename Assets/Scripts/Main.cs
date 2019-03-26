using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidDialogTest : MonoBehaviour 
{
	[SerializeField]
	private Button _startBtn;

	[SerializeField]
	private Button _stopBtn;

	void Start () 
	{
		_startBtn.onClick.AddListener( clickStart );
		_stopBtn.onClick.AddListener( clickStop );

	}

	private void clickStart()
	{
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentUnityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		currentUnityActivity.Call ("startLockTask");
	}

	private void clickStop()
	{
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentUnityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		currentUnityActivity.Call ("stopLockTask");
	}
	

}
