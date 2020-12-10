﻿using System.Collections;
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
	bool IsActiveCollisionStay = false;
	bool IsActiveCollisionStayOnWhile = false;

	// 初期化メソッド
	void Start () {
		// 自分に設定されているAnimatorコンポーネントを習得する
		this.animator = GetComponent<Animator>();
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "object" && IsActiveCollisionStay)
        {
            Jump();
			DeactivateOnCollisionStay();
        }
		if (collision.gameObject.tag == "object" && IsActiveCollisionStayOnWhile)
        {
			Jump();
        }
    }

	public void ActivateOnCollisionStay()
    {
		IsActiveCollisionStay = true;
    }

	public void DeactivateOnCollisionStay()
	{
		IsActiveCollisionStay = false;
	}

	public void ActivateOnCollisionStayOnWhile()
	{
		IsActiveCollisionStayOnWhile = true;
	}

	public void DeactivateOnCollisionStayOnWhile()
	{
		IsActiveCollisionStayOnWhile = false;
	}

	public void RightRunOnWhile()
	{
		// WaitからRunに遷移する
		this.animator.SetBool(key_isRun, true);
		this.transform.Translate(0.1f, 0, 0);
		Invoke("DelayMethod", 0.05f);
		// RunからWaitに遷移する
	}
	public void LeftRunOnWhile()
	{
		// WaitからRunに遷移する
		this.animator.SetBool(key_isRun, true);
		this.transform.Translate(-0.1f, 0, 0);
		Invoke("DelayMethod", 0.05f);
		// RunからWaitに遷移する
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
			this.transform.Translate(0.5f,2,0);
			// JumpからWait or Runに遷移する
			Invoke("DelayMethod", 0.05f);
	}
	
	// 1フレームに1回コールされる
	public void Runx()
	{
		// Wait or RunからJumpに遷移する
		this.animator.SetBool(key_isRun, true);
		string numStr = hosuu.text.ToString();
		if (numStr == "") numStr = "0";
		float x = float.Parse(numStr);
		if(x >= 10)
		{
			x = 10;
		}
		this.transform.Translate(x,0,0);
		// JumpからWait or Runに遷移する
		Invoke("DelayMethod", 0.05f);
	}
	
	public void Runy()
	{
		// Wait or RunからJumpに遷移する
		this.animator.SetBool(key_isRun, true);
		string numStr = runy.text.ToString();
		if (numStr == "") numStr = "0";
		float y = float.Parse(numStr);
		if(y >= 10)
		{
			y = 10;
		}
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