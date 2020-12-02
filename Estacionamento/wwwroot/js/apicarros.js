
/*const realCompra = document.querySelector("#marca");

function buscaBitcoin() {
    const bitcoin = fetch("https://blockchain.info/ticker");

    bitcoin
        .then((r) => {
            return r.json();
        }).then((body)=>{
            realCompra.innerText = body.BRL.buy;
        });
}

setInterval(() => {
    buscaBitcoin();
}, 5000);

    var txtCep = document.getElementById("cep");
    var txtLogradouro = document.getElementById("logradouro");
    var txtBairro = document.getElementById("bairro");
    var txtLocalidade = document.getElementById("localidade");
    var txtUf = document.getElementById("uf");
    function BuscarCep() {
        var url = `https://viacep.com.br/ws/${txtCep.value}/json/ `;
            fetch(url)
                .then(response => response.json())
                .then(json => {
        txtLogradouro.value = json.logradouro;
                    txtBairro.value = json.bairro;
                    txtLocalidade.value = json.localidade;
                    txtUf.value = json.uf;
                })
                .catch(error => console.log(error));

*/

let dropdown = $('#Marca');

dropdown.empty();

dropdown.append('<option selected="true" disabled>- Selecione -');
dropdown.prop('selectedIndex', 0);

const url = 'https://parallelum.com.br/fipe/api/v1/carros/marcas';

$.getJSON(url, function (data) {
    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.nome).text(entry.nome));
    })
});