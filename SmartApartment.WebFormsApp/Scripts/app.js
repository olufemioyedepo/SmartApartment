window.addEventListener('load', function () {
    
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
        webAuth.parseHash(function (err, authResult) {
            if (authResult && authResult.accessToken && authResult.idToken) {
                debugger;
                window.location.hash = '';
                __doPostBack('__Page', authResult.idToken)

            } else if (err) {
                console.log(err);
                boxError.value = err.error;
            }
        });
    };

    handleAuthentication();
});