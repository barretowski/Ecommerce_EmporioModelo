let indexProduto = {

    init: () => { //Local onde se encontra as funções necessárias para a pagina funcionar
        indexProduto.obterCategorias();
        let selCategoria = document.getElementById("selCategoria");
        selCategoria.innerHTML = "<option>Carregando...</option>";
        document.getElementById("iCarregandoCategoria").classList.remove("d-none");
    },

    enviar: () => {
        let dados = {
            nome: document.getElementById("txtNome").value,
            categoria: document.getElementById("selCategoria").value
        }

        HTTPClient.post("/CadastroProduto/Gravar", dados)
            .then((result) => {
                return result.json();
            })
            .then((dados) => {
                alert(dados.msg)
            })
            .catch(() => {
                alert("Erro ao cadastrar produto")
            })
    },

    obterCategorias: () => {
        HTTPClient.get("/CadastroProduto/ObterCategorias")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                indexProduto.preencherCategorias(dados);
            })
            .catch(() => {
                alert("Não foi possivel obter as categorias");
            })
    },

    preencherCategorias: (dados) => {
    
        let selCategoria = document.getElementById("selCategoria")
        let opts = "<option></option>";

        for (let i = 0; i < dados.length; i++) {
            opts += `<option value="${dados[i].id}">${dados[i].nome}</option>`;
        }
        selCategoria.innerHTML = opts;
        document.getElementById("iCarregandoCategoria").classList.add("d-none");
    }
    /*_carregarCategorias: (dados) => {

        lectedValue = "idProduto"  --> gravar na FK da tabela Produto, e passa para o produto (inserir)
         
        this.cmbCategoria.DataSource = categoria;
        this.cmbCategoria.DisplayMember = "nomeCategoria";
        this.cmbCategoria.ValueMember = "idCategoria";
        this.cmbCategoria.SelectedValue = "idProduto";

    },*/

}
document.addEventListener("DOMContentLoaded", () => {
    indexProduto.init();
})