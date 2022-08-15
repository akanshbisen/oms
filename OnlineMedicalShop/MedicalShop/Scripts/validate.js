function validateEmail()
{
    var email = document.getElementById("email").value;
    if (email == null || email == "" || email.trim().lenght == 0) {
        document.getElementById("sp1").innerHTML = "Invalid Email";
        return false;
    }
    else {
        document.getElementById("sp1").innerHTML = "";
        return true;
    }

}
function validatePass() {
    var pass = document.getElementById("password").value;
    if (pass == null || pass == "" || pass.trim().lenght == 0) {
        document.getElementById("sp2").innerHTML = "Invalid Password";
        return false;
    }
    else {
        document.getElementById("sp2").innerHTML = "";
        return true;
    }

}

function validate() {
    var flag = validateEmail();
    var flag1 = validatePass();
    if (flag && flag1) {
        return true;
    }
    else {
        return false;
    }
}