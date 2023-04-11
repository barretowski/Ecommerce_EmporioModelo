let HTTPClient = {

    get: (url) => {

        let config = {
            method: 'GET',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }

        return fetch(url, config);
    },

    post: (url, dados) => {

        let config = {
            method: 'POST',
            body: JSON.stringify(dados),
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }
        return fetch(url, config);
    },

    put: (url, dados) => {

        let config = {
            method: 'PUT',
            body: JSON.stringify(dados),
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }
        return fetch(url, config);
    },

    delete: (url) => {

        let config = {
            method: 'DELETE',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json; charset=utf-8"
            }
        }
        return fetch(url, config);
    }
}