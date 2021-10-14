﻿//Quantity box

//const { ajax } = require("jquery");
//Not sure what is the above line somehow it got generated when i was working other parts
//Reference:  https://embed.plnkr.co/plunk/B5waxZ
function wcqib_refresh_quantity_increments() {
    jQuery("div.quantity:not(.buttons_added), td.quantity:not(.buttons_added)").each(function (a, b) {
        var c = jQuery(b);
        c.addClass("buttons_added"), c.children().first().before('<input type="button" value="-" class="minus" />'), c.children().last().after('<input type="button" value="+" class="plus" />')
    })
}
String.prototype.getDecimals || (String.prototype.getDecimals = function () {
    var a = this,
        b = ("" + a).match(/(?:\.(\d+))?(?:[eE]([+-]?\d+))?$/);
    return b ? Math.max(0, (b[1] ? b[1].length : 0) - (b[2] ? +b[2] : 0)) : 0
}), jQuery(document).ready(function () {
    wcqib_refresh_quantity_increments()
}), jQuery(document).on("updated_wc_div", function () {
    wcqib_refresh_quantity_increments()
}), jQuery(document).on("click", ".plus, .minus", function () {
    var a = jQuery(this).closest(".quantity").find(".qty"),
        b = parseFloat(a.val()),
        c = parseFloat(a.attr("max")),
        d = parseFloat(a.attr("min")),
        e = a.attr("step");
    b && "" !== b && "NaN" !== b || (b = 0), "" !== c && "NaN" !== c || (c = ""), "" !== d && "NaN" !== d || (d = 0), "any" !== e && "" !== e && void 0 !== e && "NaN" !== parseFloat(e) || (e = 1), jQuery(this).is(".plus") ? c && b >= c ? a.val(c) : a.val((b + parseFloat(e)).toFixed(e.getDecimals())) : d && b <= d ? a.val(d) : b > 0 && a.val((b - parseFloat(e)).toFixed(e.getDecimals())), a.trigger("change")
});

window.onload = function () {
    /* setup event listeners for tasks selection */
    let elems = document.getElementsByClassName("input-text");
    for (let i = 0; i < elems.length; i++) {
        elems[i].addEventListener('input', UpdatePrice);
    }
          
}

function UpdatePrice(event) {
    let target = event.currentTarget;
    let productId = target.id;

    let subtotalId = "subtotal" + productId;
    let unitpriceId = "unitprice" + productId;

    let value = document.getElementById(productId).value;
    let unitprice = document.getElementById(unitpriceId).innerHTML;

    AjaxUpdateCartDB(productId, value);

    let newsubtotal = value * unitprice;
    document.getElementById(subtotalId).innerHTML = newsubtotal;
}

function AjaxUpdateCartDB(productId, value) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", "/Cart/Update");
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");

    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status == 200)
            {
                let total = document.getElementById("totalPrice");
                let data = JSON.parse(this.responseText);

                total.innerHTML = "Total: $" + data.userCartAmt;
            }
        }
    };



    let cartUpdate = {
        ProductId: productId,
        Quantity: value
    };
    xhr.send(JSON.stringify(cartUpdate));
}

