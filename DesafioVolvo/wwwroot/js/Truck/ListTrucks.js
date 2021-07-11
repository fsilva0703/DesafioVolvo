$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Truck/LoadTruckModels",
        data: "{}",
        success: function (data) {
            var s = '<option value="">Selecione</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].truckModelId + '">' + data[i].modelName + '</option>';
            }
            $("#ddlModelo").html(s);
        }
    });
});

function LoadData() {
    document.cookie = "idModel=; expires=Thu, 18 Dec 1970 12:00:00 UTC; path=/";
    document.cookie = "idModel=" + $('#ddlModelo').val() + "; expires=Thu, 18 Dec 2090 12:00:00 UTC; path=/";

    var obj = new Object();
    obj.ModelTruckId = $('#ddlModelo').val();

    var parametros = obj;

    $("#grid").DataTable({
        "destroy": true,
        "processing": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": false,
        "ajax": {
            "url": "/Truck/RequestData",
            "data": "JSON.stringify(" + parametros + ")",
            "method": "POST"
        },
        "columns": [
            { "data": "truckId" },
            { "data": "truckName" },
            { "data": "manufactureYear" },
            { "data": "modelYear" },
            {
                "render": function (data, type, full, meta) {
                    return '<a class="btn btn-info" href="/Truck/Truck?idTruck=' + full.truckId + '">Editar</a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.truckId + "'); >Deletar</a>";
                }
            },

        ]
    });
};

function DeleteData(CustomerID) {
    if (confirm("Tem certeza que deseja deletar esse registro...?")) {
        Delete(CustomerID);
    }
    else {
        return false;
    }
}

function Delete(CustomerID) {
    $.ajax({
        type: "POST",
        url: "/Truck/Delete/",
        contentType: "application/json; charset=utf-8",
        data: CustomerID,
        async: false,
        success: function (jsonResult) {
            if (jsonResult) {
                alert("Operação realizada com sucesso!");
                oTable = $('#grid').DataTable();
                oTable.draw();
            }
            else {
                alert("Ops... Ocorreu algum problema. Por favor, tente outra vez!");
            }
        }
    });
}