let indexLogin = {

    obter: () => {

        let id = 50;

        let config = {
            method: 'GET',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            },
            mode: 'cors',
            cache: 'default'
        }

        fetch("/Login/Obter?id=" + id, config)
            .then(function (retornoServidor) {
                return retornoServidor.json();
            })
            .then((dados) => {
                alert(dados.id);
            })
            .catch(() => {
                document.getElementById("divMsg").innerHTML = "Login Invalido";
            })
    },

    logar: () => {
        let emailValor = document.getElementById("txtEmail").value;
        let senhaValor = document.getElementById("txtSenha").value;

        let dados = {
            email: emailValor,
            senha: senhaValor
        }
        
        //serealiza
        let json = JSON.stringify(dados);

        HTTPClient.post("/Login/Logar", dados)
            .then(function (retornoServidor) {
                return retornoServidor.json();
            })
            .then((dados) => {
                if (!dados.sucesso)
                    document.getElementById("divMsg").innerHTML = dados.msg;
                else
                    location.href = "/Home";
            })
            .catch(() => {
                document.getElementById("divMsg").innerHTML = "Login Invalido";
            })
    },

    consultar: () => {
        let nome = encodeURIComponent("paulo%#");
        //let nomeOriginal = decodeURIComponent(nome);

        let config = {
            method: 'GET',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }
        fetch("/Login/Consultar?nome=" +nome, config)
            .then(function (retornoServidor) {
                return retornoServidor.json();
            })
            .then((dados) => {
                if (!dados.sucesso)
                    document.getElementById("divMsg").innerHTML = dados.msg;
                else
                    location.href = "/Home";
            })
            .catch(() => {
                document.getElementById("divMsg").innerHTML = "Login Invalido";
            })

    },

    alterar: () => {
        let id = 1;

        let emailValor = document.getElementById("txtEmail").value;
        let senhaValor = document.getElementById("txtSenha").value;

        let dados = {
            email: emailValor,
            senha: senhaValor
        }
        //serealiza
        let json = JSON.stringify(dados);

        let config = {
            method: 'PUT',
            body: json,
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }

        fetch("/Login/Alterar?id=" +id, config)
            .then(function (retornoServidor) {
                return retornoServidor.json();
            })
            .then((dados) => {
                alert(dados.id + " " + dados.usario.email);
            })
            .catch(() => {
                document.getElementById("divMsg").innerHTML = "Login Invalido";
            })
    },

    alterar: function() {
        
        let id = 1;

        let config = {
            method: 'DELETE',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }
        fetch("/Login/Excluir?id=" +id, config)
            .then(function (retornoServidor) {
                return retornoServidor.json();
            })
            .then((dados) => {
                alert(dados.id);
            })
            .catch(() => {
                document.getElementById("divMsg").innerHTML = "Login Invalido";
            })
    }


    
   
}