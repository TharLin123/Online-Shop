﻿


var checkpass = function ()
{
    var password = document.getElementById('password').value;
    var confirmPass = document.getElementById('confirmPass').value;
    var username = document.getElementById('userName').value;
    var password2 = document.getElementById('password').value.length;

    if (password2 < 8) {
        alert("Password requires to be at least 8 letters");
        document.getElementById("submitCreate").disabled = true;
        return;
    }
    else if (password.toLowerCase() == username.toLowerCase())
    {
        alert("Password cannot be the same as username!");
        document.getElementById("submitCreate").disabled = true;
        return;
    }
    else if (password == "")
    {
        alert("Please Enter Password!");
       document.getElementById("submitCreate").disabled = true;
        return;
    }
    else if (password.toLowerCase() != confirmPass.toLowerCase())
    {
        alert("Password & Confirm Password Do not match");
        document.getElementById("submitCreate").disabled = true;
        return;
    }
    else
    {
        alert("Password good to go!");
        document.getElementById("submitCreate").disabled = false;
        document.getElementById("password").disabled = false;
        document.getElementById("confirmPass").disabled = false;
    }

}



