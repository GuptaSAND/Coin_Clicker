using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity;
using Firebase.Unity.Editor;

public class Login : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    // Start is called before the first frame update
    public string Username;
    public string Email;
    public string Password;
    private FirebaseDatabase mDatabase;
    private DatabaseReference mDatabaseRef;
    public Login() { }
    public Login(string Username, string Email)
    {
        this.Username = Username;
        this.Email = Email;
    }
    public int Uid;

    //
    // Function : Start()
    // Description : 
    //    Initializer for the Login class
    //   
    //

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://coinclicker-f7df9.firebaseio.com/");
        FirebaseApp.DefaultInstance.SetEditorP12FileName("coinclicker-f7df9-783cfe23ec17.p12");
        FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("unity-201@coinclicker-f7df9.im.gserviceaccount.com");
        FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        mDatabase = FirebaseDatabase.GetInstance("https://coinclicker-f7df9.firebaseio.com/");

        mDatabaseRef = mDatabase.GetReference("https://coinclicker-f7df9.firebaseio.com/");


    }





    // Update is called once per frame
    void Update()
    {

    }





    void SignUp(string UserId, string Name, string email)
    {
        Login login = new Login(name, email);
        string json = JsonUtility.ToJson(login);

        mDatabaseRef.Child("users").Child(UserId).SetRawJsonValueAsync(json);
    }




    void SignIn()
    {
        Firebase.Auth.Credential credential =
    Firebase.Auth.EmailAuthProvider.GetCredential(Email, Password);
        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
}