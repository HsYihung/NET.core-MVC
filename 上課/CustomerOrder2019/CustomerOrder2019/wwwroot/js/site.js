// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function UpdateOrders() {
    $.ajax({
        type: "Get",
        /*url: "Customers/Orders/" + CustomerId.value 發行會失敗*/
        url: webroot + CustomerId.value
    }).done(function (data) {
        $("#Orders").html(data);
    }).fail(function (err) {
        alert(err.responseText);
    });
}