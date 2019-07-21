using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confpassword;
	private string Username;
	private string Email;
	private string Password;
	private string Confpassword;
	private string form;
	private bool EmailValid = false;
	/*private string[] Characters={"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p",
								"q","r","s","t","u","v","w","x","y","z","_",".","-",
								"0","1","2","3","4","5","6","7","8","9"};*/

	// Use this for initialization
	void Start () {
		
	}
	public void RegisterButton(){
		bool un = false;
		bool em = false;
		bool pw = false;
		bool cpw = false;

		if (Username != "") {
			if (!System.IO.File.Exists (@"/home/sonika/Documents/UserFile" + Username + ".txt")) {
				un = true;
			} else {
				Debug.LogWarning ("Username Taken");
			}	
		} else {
			Debug.LogWarning ("Username field empty");
		}
		if (Email != "") {
			//EmailValidation ();
			if (EmailValid) {
				if (Email.Contains ("@")) {
					if (Email.Contains (".")) {
						em = true;
					} else {
						Debug.LogWarning ("Incorrect email");
					}
				} else {
					Debug.LogWarning ("Incorrect email");
				}
			} else {
				Debug.LogWarning ("Incorrect email");
			}
		
		} else {
			Debug.LogWarning ("Required email field");
		}
		if (Password != "") {
			if (Password.Length > 5) {
				pw = true;

			} else {
				Debug.LogWarning ("Password must be atleast 6 char long");
			}
		} else {
			Debug.LogWarning ("Password field required");
		}
		if (Confpassword != "") {
			if (Confpassword == Password) {
				cpw = true;
			} else {
				Debug.LogWarning ("No matching password");
			}
		} else {
			Debug.LogWarning ("Required Confirm password field");
		}
		if (un == true && em == true && pw == true && cpw == true) {
			bool clear = true;
			int i = 1;
			foreach (char c in Password) {
				if (clear) {
					Password = "";
					clear = false;
				}
				i++;
				char Encrypted = (char)(c * i);
				Password += Encrypted.ToString ();

			}
			form = (Username + "\n" + Email + "\n" + Password);
			System.IO.File.WriteAllText (@"/home/sonika/Documents/UserFile + Username + .txt", form);
			username.GetComponent<InputField> ().text= "";
			email.GetComponent<InputField> ().text="";
			password.GetComponent<InputField> ().text="";
			confpassword.GetComponent<InputField>().text="";
			print("Registration complete");
		}

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

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Username != "" && Email != "" && Password != "" && Confpassword != "") {
				RegisterButton ();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Email = email.GetComponent<InputField> ().text;
		Password= password.GetComponent<InputField> ().text;
		Confpassword = confpassword.GetComponent<InputField>().text;

	}
	/*void EmailValidation(){
		bool sw = false;
		bool ew = false;
		for (int i = 0; i < Characters.Length; i++) {
			if (Email.StartsWith (Characters [i])) {
				sw = true;
			}
		}
		for (int i = 0; i < Characters.Length; i++) {
			if (Email.StartsWith (Characters [i])) {
				ew = true;
			}
		}
		if (sw == true && ew == true) {
			EmailValid = true;
		} else {
			EmailValid = false;
		}
	
	}*/
}
