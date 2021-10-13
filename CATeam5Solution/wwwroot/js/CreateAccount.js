var checkpass = function () {

    if (document.getElementById('password').value =="" || document.getElementById('confirmPass').value=="")
    {
        alert("Please Enter Password!")
        document.getElementById("submitCreate").disabled = true;
        return;
    }
    if (document.getElementById('password').value.length < 8 || document.getElementById('confirmPass').value.length < 8)
    {
        alert("Password requires to be at least 8 letters")
        document.getElementById("submitCreate").disabled = true;
        return;
    }

    if (document.getElementById('password').value !=
        document.getElementById('confirmPass').value) {
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

