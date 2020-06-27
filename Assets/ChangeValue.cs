using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ValueKind {

fallSpeed, //=2.5f;
	lowJumpSpeed,//=-2f;
	moveSpeed,
	moveIf,
	 GroundedRadius,
	 jumpTime,//3
	 walkingTreshold,
	 jumpingTreshold,
	 slowXwhenReleased
	}

public class ChangeValue : MonoBehaviour
{
	public PlayerCharacter pc;
	public ValueKind value;
	public Text text;
	public float scale=1f;

    void  Start()
    {
        text.text = value+": "+getValue();
    }

	object getValue(){
    		if(value==ValueKind.fallSpeed)
    			return pc.fallSpeed;
    		if(value==ValueKind.lowJumpSpeed)
    			return pc.lowJumpSpeed;
    		if(value==ValueKind.moveSpeed)
    			return pc.moveSpeed;
    		if(value==ValueKind.moveIf)
    			return pc.moveIf;
    		if(value==ValueKind.GroundedRadius)
    			return pc.GroundedRadius;
    		if(value==ValueKind.jumpTime)
    			return pc.jumpTime;
    		if(value==ValueKind.walkingTreshold)
    			return pc.walkingTreshold;
    		if(value==ValueKind.jumpingTreshold)
    			return pc.jumpingTreshold;
    		if(value==ValueKind.slowXwhenReleased)
    			return pc.slowXwhenReleased;
    		
    		
    		return "NOT IMPL"+value+"?";
    	}

public void changeVal(float f){
Debug.Log(value+": "+f);
var x=f*scale;

			if(value==ValueKind.fallSpeed)
    			pc.fallSpeed = x;
    		if(value==ValueKind.lowJumpSpeed)
    			pc.lowJumpSpeed = x;
    		if(value==ValueKind.moveSpeed)
    			pc.moveSpeed = x;
    		if(value==ValueKind.moveIf)
    			pc.moveIf = x;
    		if(value==ValueKind.GroundedRadius)
    			pc.GroundedRadius = x;
    		if(value==ValueKind.jumpTime)
    			pc.jumpTime = x;
    		if(value==ValueKind.walkingTreshold)
    			pc.walkingTreshold = x;
    		if(value==ValueKind.jumpingTreshold)
    			pc.jumpingTreshold = x;
    		if(value==ValueKind.slowXwhenReleased)
    			pc.slowXwhenReleased = x;

    		Start();
}

    void Update()
    {
        
    }
}
