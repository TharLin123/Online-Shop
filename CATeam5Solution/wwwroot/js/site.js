// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

addToCart = function(productId) {

    var xhr = new XMLHttpRequest();
    let url = "/ShoppingCart/AddToCart/" + productId
    xhr.open("POST", url);
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {

            if (this.status !== 200) return;

            let data = JSON.parse(this.responseText);
            document.getElementById('CartCount').innerHTML = data.cartCount;
            let cartItem = data.shoppingCart.find(item => item["ProductId"] == productId)
            if(cartItem != null){
                document.getElementById(productId).innerHTML = cartItem.Amount;
            }else {
                document.getElementById(productId).innerHTML = '';
            }
        }
    };

    xhr.send();
}

removeFromCart = function(productId) {

    var xhr = new XMLHttpRequest();
    let url = "/ShoppingCart/RemoveFromCart/" + productId
    xhr.open("POST", url);
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {

            if (this.status !== 200) return;

            let data = JSON.parse(this.responseText);
            document.getElementById('CartCount').innerHTML = data.cartCount;
            let cartItem = data.shoppingCart.find(item => item["ProductId"] == productId)
            if(cartItem != null){
                document.getElementById(productId).innerHTML = cartItem.Amount;
            } else {
                document.getElementById(productId).innerHTML = '';
            }
        }
    };

    xhr.send();
}
