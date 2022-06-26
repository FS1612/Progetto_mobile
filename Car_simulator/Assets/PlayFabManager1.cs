using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class PlayFabManager1 : MonoBehaviour
{
    
    public Text messageText;
    public InputField emailnput;
    public InputField passwordInput;
    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailnput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError); 
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
    }
   

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailnput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, onLoginSuccess, OnError);
        
    } 
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailnput.text,
            TitleId = "98535"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);

    }
        void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }

    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
     void onLoginSuccess (LoginResult result)
    {
        messageText.text = "Logged in!";
        Debug.Log("Successful login/account create");
      
    }
void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while loggin in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }

   // void OnError(PlayFabError error)
  //  {
   //     messageText.text = error.ErrorMessage;
     //   Debug.Log(error.GenerateErrorReport());
   // }
}
