


var checkpass = function ()
{
    var password = document.getElementById('password').value
    var confirmPass = document.getElementById('confirmPass').value

    if (password == "")
    {
       alert("Please Enter Password!")
       document.getElementById("submitCreate").disabled = true;
        return;
    }
    if (password < 8)
    {
        alert("Password requires to be at least 8 letters")
        document.getElementById("submitCreate").disabled = true;
        return;
    }
    if (password != confirmPass) {
        alert("Password & Confirm Password Do not match");
        document.getElementById("submitCreate").disabled = true;
        return;
    }
    else
    {
        alert("Password good to go!")
        document.getElementById("submitCreate").disabled = false;
    }

}



