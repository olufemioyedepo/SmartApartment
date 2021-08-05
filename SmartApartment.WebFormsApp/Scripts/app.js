window.addEventListener('load', function () {
    console.log('load now');
    var webAuth = new auth0.WebAuth({
        domain: 'dev-vsq6sv2h.us.auth0.com',
        clientID: 'vh8uYjysSlo2A6qEAu2koYF3cZHxspLb',
        responseType: 'token id_token',
        scope: 'openid profile',
        redirectUri: window.location.href
    });
    var loginBtn = document.getElementById('loginLink');
    loginBtn.addEventListener('click', function (e) {
        console.log('click now');
        e.preventDefault();
        webAuth.authorize();
    });
    function handleAuthentication() {
        var boxAccessToken = document.getElementById('accessTokeInput');
        var boxIdToken = document.getElementById('idTokenInput');
        var boxError = document.getElementById('errorInput');
        console.log('handleAuthentication now');
        webAuth.parseHash(function (err, authResult) {
            if (authResult && authResult.accessToken && authResult.idToken) {
                debugger;
                window.location.hash = '';
                boxAccessToken.value = authResult.accessToken;
                boxIdToken.value = authResult.idToken;
                // Comment out the following if you want to stop and display the results of authentication.
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                __doPostBack('__Page', authResult.idToken)
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            } else if (err) {
                console.log(err);
                boxError.value = err.error;
            }
        });
    }
    handleAuthentication();
});