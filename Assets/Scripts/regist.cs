using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NCMB;

public class regist : MonoBehaviour
{
	NCMBUser currentUser;
	// Use this for initialization
	void Start()
	{
		currentUser = NCMBUser.CurrentUser;
		if (currentUser != null)
		{
			// ログイン中のユーザーの取得に成功
			UnityEngine.Debug.Log("ログイン中のユーザー: " + currentUser.UserName);
		}
		else
		{
			// 未ログインまたは取得に失敗
			UnityEngine.Debug.Log("未ログインまたは取得に失敗");
		}
	}

	public void OnClickStartButton()
	{
		NCMBUser.LogOutAsync((NCMBException e) => {
			if (e != null)
			{
				UnityEngine.Debug.Log("ログアウトに失敗: " + e.ErrorMessage);
			}
			else
			{
				UnityEngine.Debug.Log("ログアウトに成功");
				SceneManager.LoadScene("start");
			}
		});
    }
}
