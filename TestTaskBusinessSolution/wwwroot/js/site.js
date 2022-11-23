// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.

function ApplyFilters() {
    var formData = $("#filtersOrdersForm").serialize();
    $.ajax({
        url: "/Orders/ApplyFilters",
        type: "POST",
        data: formData,
        success: function (result) {
            $("#ordersPartial").html(result);
        }
    });
}

function UpdateOrder() {
    var orId = $("#txtOrderId");
    var orNum = $("#orderNumber");
    var orDate = $("#orderDate");
    var orProvId = $("#orderProviderId");
    $.ajax({
        url: "/Orders/Update",
        type: "POST",
        data: {
            Id: orId.val(),
            Number: orNum.val(),
            Date: orDate.val(),
            ProviderId: orProvId.val()
        },
        success: function (result) {
            alert(result);
        },
        error: function (result) {
            alert(result);
        }
    });
}

function CreateOrder() {
    var formData = $("#createOrderForm").serialize();
    $.ajax({
        url: "/Orders/Create",
        type: "POST",
        data: formData,
        success: function (response) {
            if (response.success) {
                alert(response.message);
                location.href = response.redirect; 
            } else {
                alert(response.message);
            }
        },
        error: function (response) {
            alert(response.message);
        }
    });
}


function DeleteOrder() {
    if (confirm("Вы хотите удалить этот заказ?")) {
        var orderId = $("#delOrderId");
        $.ajax({
            url: "/Orders/Delete",
            type: "PUT",
            data: {
                id: orderId.val()
            },
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    location.href = response.redirect;                   
                } else {
                    alert(response.message);
                }
            },
            error: function (response) {
                alert(response);
            }
        });
    }
}

var nameTemp = {};
var quantityTemp = {};
var unitTemp = {};

function AppendRow(row, itemId, name, quantity, unit) {
    //Bind CustomerId.
    $(".ItemId", row).find("span").html(itemId);

    //Bind Name.
    $(".Name", row).find("span").html(name);
    $(".Name", row).find("input").val(name);

    //Bind Quantity.
    $(".Quantity", row).find("span").html(quantity);
    $(".Quantity", row).find("input").val(quantity);

    //Bind Unit.
    $(".Unit", row).find("span").html(unit);
    $(".Unit", row).find("input").val(unit);

    row.find(".Edit").show();
    row.find(".Delete").show();
    $("#tblItems").append(row);
};

//Add event handler.
$("body").on("click", "#btnAdd", function () {
    var txtOrderId = $("#txtOrderId");
    var txtName = $("#txtName");
    var txtQuantity = $("#txtQuantity");
    var txtUnit = $("#txtUnit");
    $.ajax({
        url: "/Items/Create",
        type: "POST",
        data: {
            OrderId: txtOrderId.val(),
            Name: txtName.val(),
            Quantity: txtQuantity.val(),
            Unit: txtUnit.val()
        },
        success: function (response) {
            if (response.success) {
                var row = $("#tblItems tr:last-child");
                if ($("#tblItems tr:last-child span").eq(0).html() != "&nbsp;") {
                    row = row.clone();
                }
                AppendRow(row, response.id, response.name, response.quantity, response.unit);
                txtName.val("");
                txtQuantity.val("");
                txtUnit.val("");
                if (row.length == 1) {
                    location.reload();
                }
            } else {
                alert(response.message);
            }
        },
        error: function (response) {
            alert(response)
        }
    });
});


//Edit event handler.
$("body").on("click", "#tblItems .Edit", function () {
    var row = $(this).closest("tr");
    nameTemp = row.find(".Name").find("span").html();
    quantityTemp = row.find(".Quantity").find("span").html();
    unitTemp = row.find(".Unit").find("span").html();
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            $(this).find("input").show();
            $(this).find("span").hide();
        }
    });
    row.find(".Update").show();
    row.find(".Cancel").show();
    row.find(".Delete").hide();
    $(this).hide();
});

//Update event handler.
$("body").on("click", "#tblItems .Update", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            span.html(input.val());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Cancel").hide();
    $(this).hide();
    var itemId = row.find(".ItemId").find("span").html();
    var name = row.find(".Name").find("span").html();
    var quantity = row.find(".Quantity").find("span").html();
    var unit = row.find(".Unit").find("span").html();
    $.ajax({
        type: "POST",
        url: "/Items/Update",
        data: {
            Id: itemId,
            Name: name,
            Quantity: quantity,
            Unit: unit
        },
        success: function (response) {
            if (!response.success) {
                ResetUpdate(row);
                alert(response.message)
            };
        },
        error: function (response) {
            ResetUpdate(row);
            alert(response);
        }
    });
});

function ResetUpdate(row) {
    $(".Name", row).find("span").html(nameTemp);
    $(".Name", row).find("input").val(nameTemp);

    $(".Quantity", row).find("span").html(quantityTemp);
    $(".Quantity", row).find("input").val(quantityTemp);

    $(".Unit", row).find("span").html(unitTemp);
    $(".Unit", row).find("input").val(unitTemp);
};

//Cancel event handler.
$("body").on("click", "#tblItems .Cancel", function () {
    var row = $(this).closest("tr");
    $("td", row).each(function () {
        if ($(this).find("input").length > 0) {
            var span = $(this).find("span");
            var input = $(this).find("input");
            input.val(span.html());
            span.show();
            input.hide();
        }
    });
    row.find(".Edit").show();
    row.find(".Delete").show();
    row.find(".Update").hide();
    $(this).hide();
});

//Delete event handler.
$("body").on("click", "#tblItems .Delete", function () {
    if (confirm("Вы хотите удалить эту строку?")) {
        var row = $(this).closest("tr");
        var itemId = row.find("span").html();
        $.ajax({
            type: "POST",
            url: "/Items/Delete",
            data:
            {
                id: itemId
            },
            success: function () {
                if ($("#tblItems tr").length > 1) {
                    row.remove();
                } else {
                    row.find(".Edit").hide();
                    row.find(".Delete").hide();
                    row.find("span").html('&nbsp;');
                }
            }
        });
    }
});


