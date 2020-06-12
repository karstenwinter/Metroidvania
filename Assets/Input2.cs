using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static class Input2{
public static  float hor = Single.NaN;
public static  bool? jump = null;
public static  float GetAxis(string s){
return s=="Horizontal"?Single.IsNaN(hor)?Input.GetAxis(s):hor:0;
}
public static  bool GetButton(string s){
return s=="Jump"?jump == null?Input.GetButton(s):jump.Value :false;
}
}