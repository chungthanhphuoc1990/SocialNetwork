function FormatNumber(str) {
    var strTemp = GetNumber(str);
    if (strTemp.length <= 3)
        return strTemp;
    var strResult = "";
    var i;
    for (i = 0; i < strTemp.length; i++)
        strTemp = strTemp.replace(",", "");
    for (i = strTemp.length; i >= 0; i--) {
        if (strResult.length > 0 && (strTemp.length - i - 1) % 3 == 0)
            strResult = "," + strResult;
        strResult = strTemp.substring(i, i + 1) + strResult;
    }
    return strResult;
}
function GetNumber(str) {
    for (var i = 0; i < str.length; i++) {
        var temp = str.substring(i, i + 1);
        if (!(temp == "," || temp == "." || (temp >= 0 && temp <= 9))) {
            alert("Vui lòng nhập số (0-9)!");
            return str.substring(0, i);
        }
        if (temp == " ")
            return str.substring(0, i);
    }
    return str;
}

function TongSoKhac(str) {
    var strTemp = GetNumber(str);

    return strResult;
}
function LengthComment(str) {
    $("#charLeft").text(str.length + ' char');
}
function ValidateKeypress(numcheck, e) {
    var keynum, keychar;
    if (window.event) {//IE
        keynum = e.keyCode;
    }
    else if (e.which) {// Netscape/Firefox/Opera
        keynum = e.which;
    }
    if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
    keychar = String.fromCharCode(keynum);
    var result = numcheck.test(keychar);
    return result;
}