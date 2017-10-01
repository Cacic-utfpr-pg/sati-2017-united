using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown {

	public GameObject parent = null;
    public string method = null;
    public float cooldown = 0;
    private bool inCooldown;
    private float timer;
	public int flag;

	public Cooldown(GameObject parent, string method, float cooldown, int flag){
		this.parent = parent;
		this.method = method;
		this.cooldown = cooldown;
		this.flag = flag;
		Start ();
	}

	public Cooldown(GameObject parent, string method, float cooldown){
		this.parent = parent;
		this.method = method;
		this.cooldown = cooldown;
		Start ();
	}

	private void Start(){
		inCooldown = false;
		timer = 0;
	}

	public float getTimer(){ return this.timer; }

    public void Update()
    {
        if (inCooldown)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Warns();
            }
        }

    }

    public bool isCooldown() { return this.inCooldown; }

    public void StartCooldown()
    {
        if (!inCooldown)
        {
            timer = cooldown;
            inCooldown = true;
        }
    }

    public void RestartCooldown()
    {
        timer = cooldown;
        inCooldown = true;
    }

    private void Warns()
    {
        inCooldown = false;
		Debug.Log("Cooldown::Warns " + parent.tag);
		int[] args = new int[3];
		args [0] = flag;
		args [1] = (int) timer;
		if(method != null && parent != null) 
			parent.SendMessageUpwards(method, args);
       
    }

}
