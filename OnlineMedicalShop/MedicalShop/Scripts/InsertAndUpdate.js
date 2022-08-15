function validateName() {
    var name = document.getElementById("name").value;
    if (name == null || name == "" || name.trim().lenght == 0) {
        document.getElementById("sp1").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp1").innerHTML = "";
        return true;
    }
}
function validateCompany() {
    var company = document.getElementById("company").value;
    if (company == null || company == "" || company.trim().lenght == 0) {
        document.getElementById("sp2").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp2").innerHTML = "";
        return true;
    }
}
function validateCategory() {
    var cat = document.getElementById("category").value;
    if (cat == null || cat == "" || cat.trim().lenght == 0) {
        document.getElementById("sp3").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp3").innerHTML = "";
        return true;
    }
}
function validateQuantity() {
    var q = document.getElementById("quantity").value;
    if (q == null || q == "" || q.trim().lenght == 0) {
        document.getElementById("sp4").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp4").innerHTML = "";
        return true;
    }
}
function validatePrice() {
    var p = document.getElementById("price").value;
    if (p == null || p == "" || p.trim().lenght == 0) {
        document.getElementById("sp5").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp5").innerHTML = "";
        return true;
    }
}
function validateDescription() {
    var des = document.getElementById("description").value;
    if (des == null || des == "" || des.trim().lenght == 0) {
        document.getElementById("sp6").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp6").innerHTML = "";
        return true;
    }
}
function validateImg() {
    var img = document.getElementById("imgurl").value;
    if (img == null || img == "" || img.trim().lenght == 0) {
        document.getElementById("sp7").innerHTML = "Required Field";
        return false;
    }
    else {
        document.getElementById("sp7").innerHTML = "";
        return true;
    }

}

function validate()
{
    var f0 = validateName();
    var f1 = validateCompany();
    var f2 = validateCategory();
    var f3 = validateQuantity();
    var f4 = validatePrice();
    var f5 = validateDescription();
    var f6 = validateImg();
    if (f0 && f1 && f2 && f3 && f4 && f5 && f6) {
        return true;
    }
    else {
        return false
    }
}