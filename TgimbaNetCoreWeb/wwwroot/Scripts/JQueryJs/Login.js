

function LoginDemoUser() {
    var goodToken = false;

    goodToken = CallService('/Services/BucketListServices.svc/LoginDemoUser',
                            'post',
                             'application/json; charset=utf-8');

    return goodToken;
}
function ProcessToken(token) {
    var goodToken = false;
    var base64Token = btoa(token);

    goodToken = CallService('/Services/BucketListServices.svc/ProcessToken',
                            'post',
                             'application/json; charset=utf-8',
                             JSON.stringify({ token: base64Token }));

    return goodToken;
}
function Register(userName, email, passWord) {
    var userAdded = false;
    var base64UserName = btoa(userName);
    var base64Email = btoa(email);
    var base64PassWord = btoa(passWord);

    userAdded = CallService('/Services/BucketListServices.svc/ProcessUserRegistration',
                            'post',
                             'application/json; charset=utf-8',
                             JSON.stringify({ encodedUser: base64UserName, encodedEmail: base64Email, encodedPass: base64PassWord }));

    return userAdded;
}
function ValidateGoodRegistrationValues(user, email, pass, confirmPass) {
    var regValidationMsg = null;
    
    if (user == null || user == 'null' || user == '')
        regValidationMsg = 'Please enter username';

    else if (regValidationMsg == null && (email == null || email == 'null' || email == ''))
        regValidationMsg = 'Please enter email';

    else if (regValidationMsg == null && (pass == null || pass == 'null' || pass == ''))
        regValidationMsg = 'Please enter password';

    else if (regValidationMsg == null && (confirmPass == null || confirmPass == 'null' || confirmPass == ''))
        regValidationMsg = 'Please type password in the confirmation field';
        
    else if (regValidationMsg == null && user.length < 8)
        regValidationMsg = 'Username must be at leasth 8 characters in length';

    else if (regValidationMsg == null && pass.length < 8)
        regValidationMsg = 'Password must be at leasth 8 characters in length';

    else if (regValidationMsg == null && !ContainsOneNumber(pass))
        regValidationMsg = 'Password must contain at least one number';

    else if (regValidationMsg == null && confirmPass != pass)
        regValidationMsg = 'Password and the confirmation password are not the same value';

    else if (regValidationMsg == null && email.indexOf("@") < 1)
        regValidationMsg = 'Please enter a valid email';

    return regValidationMsg;
}
function ContainsOneNumber(pass) {
    var charArray = pass.split('');
    var numberFound = false;

    for (var i = 0; i < charArray.length; i++) {
        if ($.isNumeric(charArray[i]))
        {
            numberFound = true;
            break;
        }
    }

    return numberFound;
}