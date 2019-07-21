using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRegister : MonoBehaviour {
	public InputField Username;
	public InputField Password;
	public InputField Email;
	public Button Register;

	public void CallSignUp()
	{
		StartCoroutine(Registration());
	}
	IEnumerator Registration()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", Username.text);
		form.AddField("password", Password.text);

		WWW www = new WWW("hhtp://localhost/sqlconnect/userprofile.php", form);
		yield return www;
		if (www.text == "0")
		{
			Debug.Log("User created successfully.");

		}
		else
		{
			Debug.Log("User creation  Failed.Error #" + www.text);
		}

	}

}