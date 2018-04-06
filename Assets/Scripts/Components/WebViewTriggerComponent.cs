﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewTriggerComponent : MonoBehaviour
{
	//public GameObject exclaimationGO;
	public GameObject vRWebViewGO;
	// TODO needs #define
	public ZenFulcrum.EmbeddedBrowser.Browser browser;
	private string thisURL;

	private void Start()
	{
		DisableWebView();
	}

	public void SetURL(string url)
	{
		thisURL = url;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			ControlManager.instance.SendWebViewMissive(thisURL);
		}

		// TODO needs #define
		if (other.tag == "VRPlayer")
		{
			EnableWebView();

			this.transform.LookAt(other.transform.position);
			this.transform.rotation = Quaternion.Euler(new Vector3(0, this.transform.rotation.eulerAngles.y, 0));
			if (browser != null)
				browser.Url = thisURL;
		}
	}

	public void DisableWebView()
	{
		if (vRWebViewGO != null)
			vRWebViewGO.SetActive(false);
	}

	private void EnableWebView()
	{
		if (vRWebViewGO != null)
			vRWebViewGO.SetActive(true);
	}
}
