using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanAttempt : MonoBehaviour {

	// Animator コンポーネント
	public Animator animator;

	// 設定したフラグの名前
	public const string key_isRun = "isRun";
	public const string key_isJumpup = "isJumpup";
	// public InputField inputField;

	public Text hosuu;
	public Text runy;

	// 初期化メソッド
	void Start () {
		// 自分に設定されているAnimatorコンポーネントを習得する
		this.animator = GetComponent<Animator>();
	}

	public void RightRun()
	{
			// WaitからRunに遷移する
			this.animator.SetBool(key_isRun, true);
			this.transform.Translate(1,0,0);
			Invoke("DelayMethod", 0.05f);
			// RunからWaitに遷移する
	}

	public void LeftRun()
	{
			// WaitからRunに遷移する
			this.animator.SetBool(key_isRun, true);
			this.transform.Translate(-1,0,0);
			Invoke("DelayMethod", 0.05f);
			// RunからWaitに遷移する
	}

	public void Jump()
	{
			// Wait or RunからJumpに遷移する
			this.animator.SetBool(key_isJumpup, true);
			this.transform.Translate(0,1,0);
			// JumpからWait or Runに遷移する
			Invoke("DelayMethod", 0.05f);
	}
	
	// 1フレームに1回コールされる
	public void Runx()
	{
			// Wait or RunからJumpに遷移する
			this.animator.SetBool(key_isRun, true);
			GameObject inputField = GameObject.Find("InputField");
			// Debug.Log(hosuu.text);
			float x = float.Parse(hosuu.text.ToString());
			this.transform.Translate(x,0,0);
			// JumpからWait or Runに遷移する
			Invoke("DelayMethod", 0.05f);
	}
	
	public void Runy()
	{
			// Wait or RunからJumpに遷移する
			this.animator.SetBool(key_isRun, true);
			GameObject inputField = GameObject.Find("InputField");
			// Debug.Log(hosuu.text);
			float y = float.Parse(runy.text.ToString());
			this.transform.Translate(-y,0,0);
			// JumpからWait or Runに遷移する
			Invoke("DelayMethod", 0.05f);
	}
	
	

	void DelayMethod()
    {
        this.animator.SetBool(key_isJumpup, false);
		this.animator.SetBool(key_isRun, false);
	}
}