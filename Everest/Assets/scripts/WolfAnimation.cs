﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnimation
{
	Run,
	Stay,
	sniff,
	sit
}
public class WolfAnimation : MonoBehaviour
{
	Animator anim;
	void Start()
    {
		anim = GetComponent<Animator>();
	}
	
    public void GetAnimation(List<StateAnimation> Animate)
    {
		var index = GetComponent<WolfMoveLogic>().index;
		if(index >= Animate.Count)
		{
			anim.Play("wolf_rig|idle2");
			anim.speed = 0.5f;
		}
		else if(Animate[index] == StateAnimation.sit)
		{
				anim.Play("wolf_rig|idle2");
				anim.speed = 0.5f;
		}
		else if (Animate[index] == StateAnimation.sniff)
		{
				anim.Play("wolf_rig|sniffing");
				anim.speed = 0.35f;
		}
		else if (Animate[index] == StateAnimation.Stay)
		{
			anim.Play("wolf_rig|default");
			anim.speed = 1f;
		}
	}

	public void GetAnimation()
	{
		anim.Play("wolf_rig|running");
		anim.speed = 1f;
	}
}
