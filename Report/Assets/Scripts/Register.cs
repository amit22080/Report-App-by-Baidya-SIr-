using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Register : MonoBehaviour {

	MySQL mysql;

	public Text username,password,gender,userType;

	void Start()
	{
		mysql = GetComponent<MySQL>();
	}

	public void registerUser()
	{
		try
		{
			if (!(string.IsNullOrEmpty(username.text) || string.IsNullOrWhiteSpace(username.text) || string.IsNullOrEmpty(password.text) || string.IsNullOrWhiteSpace(password.text)))
			{
				string query = "INSERT INTO users VALUES('" + username.text + "','" + password.text + "','" + gender.text.ToCharArray()[0] + "','" + userType.text + "');";
				mysql.executeUpdate(query);
			}
			else
			{
				Debug.LogError("One of the fields is blank,Plz fill and try again");
			}

			print("REGISTRATION SUCCESSFUL!");
		}
		catch (Exception e)
		{
			Debug.LogError(e.Message.ToString());
		}
	}

	
	
}
