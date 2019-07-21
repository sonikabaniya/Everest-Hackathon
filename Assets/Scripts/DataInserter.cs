using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class DataInserter : MonoBehaviour {

	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confpassword;

	public string inputUserName;
	public string inputPassword;
	public string inputConfPassword;
	public string inputEmail;

	string CreateUserURL = "localhost/ARRoomie/InsertUser.php";

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				email.GetComponent<InputField> ().Select ();
			}
			if (email.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
			if (password.GetComponent<InputField> ().isFocused) {
				confpassword.GetComponent<InputField> ().Select ();
			}
		}



		if (Input.GetKeyDown (KeyCode.Space)) CreateUser (inputUserName, inputPassword, inputEmail);


		inputUserName = username.GetComponent<InputField> ().text;
		inputEmail = email.GetComponent<InputField> ().text;
		inputPassword= password.GetComponent<InputField> ().text;
		inputConfPassword = confpassword.GetComponent<InputField>().text;

		
	}

	public void CreateUser(string username, string password, string email){
		//Debug.Log ("hjhsjhs");
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		form.AddField("emailPost", email);

		WWW www = new WWW(CreateUserURL, form);
	}
}
