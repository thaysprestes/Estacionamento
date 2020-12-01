
const realCompra = document.querySelector(".realCompra");

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
}, 10000);


