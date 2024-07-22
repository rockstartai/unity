using Firebase.Auth;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace W2D5.Microservices
{
	public class W2D5AuthUI : MonoBehaviour
	{
		[SerializeField] TMP_InputField _emailInput;
		[SerializeField] TMP_InputField _passwordInput;
		[SerializeField] Button _registerButton;
		[SerializeField] Button _loginButton;

		FirebaseAuth _auth;


		void Start()
		{
			_auth = FirebaseAuth.DefaultInstance;
			_loginButton.onClick.AddListener(HandleLogin);
			_registerButton.onClick.AddListener(HandleRegister);
		}

		void HandleLogin()
		{
			string email = _emailInput.text;
			string password = _passwordInput.text;
			_auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
			{
				if (task.IsFaulted)
				{
					Debug.LogError("Login failed: " + task.Exception);
					// Handle login failure (e.g., display an error message)
				}
				else if (task.IsCompleted)
				{
					var user = task.Result.User;
					Debug.Log("Login successful! User: " + user.Email);
					// Handle successful login (e.g., navigate to a different scene)
				}
			});
		}

		void HandleRegister()
		{
			string email = _emailInput.text;
			string password = _passwordInput.text;
			_auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
			{
				if (task.IsFaulted)
				{
					Debug.LogError("Registration failed: " + task.Exception);
					// Handle registration failure (e.g., display an error message)
				}
				else if (task.IsCompleted)
				{
					var user = task.Result.User;
					Debug.Log("Registration successful! User: " + user.Email);
					// Handle successful registration (e.g., display a success message or navigate to login)
				}
			});
		}
	}
}
