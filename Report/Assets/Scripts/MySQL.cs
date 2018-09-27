using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class MySQL : MonoBehaviour {

	public string Database;
	public string Server;
	public string Username;
	public string Password;

	private MySqlCommand cmd;
	private MySqlDataReader reader;
	private string currDatabase="";
	private bool isDatabaseConnected=false;

	// Use this for initialization
	void Start () {

		connectDatabase();
	}

	#region Database Connection
	void connectDatabase()
	{
		try
		{
			//datasource=localhost; database=amit; username=root; password=amit;
			string conURL = "Datasource=" + Server + ";database=" +Database+";username=" + Username + ";password=" + Password + ";port=3306";
			MySqlConnection con = new MySqlConnection(conURL);
			con.Open();

			cmd = con.CreateCommand();
			cmd.CommandType = CommandType.Text;

			//Creating database and again connecting
			currDatabase = Database;

			onConnection();

			isDatabaseConnected = true;
			print("CONNECTED to " + currDatabase);
		}
		catch (Exception e)
		{
			print(e.Message);
		}
	}

	void onConnection()
	{
		//Creating a table if not exists
		string query = "CREATE TABLE IF NOT EXISTS users(userID VARCHAR(50) UNIQUE PRIMARY KEY,password VARCHAR(50) NOT NULL,Gender CHAR default 'M',UserType VARCHAR(10) default'Student')";
		executeUpdate(query);
	}
	#endregion

	public void executeUpdate(string query)
	{
			cmd.CommandText=query;
			cmd.ExecuteNonQuery();
	}

	public MySqlDataReader executeQuery(string query)
	{
		
		return null;
	}
}
