var _truckModelId = 0;

$(document).ready(function () {
    var _truckId = location.search.slice(1).split("=");

    if (_truckId[0] !== null && _truckId[0] !== undefined && _truckId[0] !== "") {
        var obj = new Object();
        obj.truckId = _truckId[1];

        $.ajax({
            type: "POST",
            url: "/Truck/SelectTruckByTruckId/",
            contentType: "application/json; charset=utf-8",
            data: obj.truckId,
            async: false,
            success: function (jsonResult) {
                if (jsonResult.truckId !== 0) {
                    _truckId = jsonResult.truckId;
                    _truckModelId = jsonResult.truckModelId;
                    _truckName = jsonResult.truckName;
                    _manufactureYear = jsonResult.manufactureYear;
                    _modelYear = jsonResult.modelYear;
                    $('#nome').val(_truckName);
                    $('#anoFabricacao').val(_manufactureYear);
                    $('#anoModelo').val(_modelYear);
                }
            }
        });
    }
});

$("#ddlModelo").attr('disabled', 'disabled');

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Truck/LoadTruckModels",
        data: "{}",
        success: function (data) {
            var x = '<option value="">Selecione</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].truckModelId == _truckModelId) {
                    x += '<option value="' + data[i].truckModelId + '" selected>' + data[i].modelName + '</option>';
                }
                else {
                    x += '<option value="' + data[i].truckModelId + '">' + data[i].modelName + '</option>';
                }
            }
            $("#ddlModelo").html(x);
            $("#ddlModelo").attr('enable', 'enable');
        }
    });
});

function SetTruck() {
    var _idTruck = location.search.slice(1).split("=");

    var obj = new Object();

    if (_idTruck[1] == null || _idTruck[1] == undefined)
        obj.TruckId = 0
    else
        obj.TruckId = parseInt(_idTruck[1]);

    obj.TruckName = $('#nome').val();
    obj.TruckModelId = parseInt($('#ddlModelo').val());
    obj.ManufactureYear = parseInt($('#anoFabricacao').val());
    obj.ModelYear = parseInt($('#anoModelo').val());

    var parametros = obj;

    $.ajax({
        type: "POST",
        url: "/Truck/Maintain/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(parametros),
        dataType: "json",
        async: false,
        success: function (jsonResult) {
            if (jsonResult.isValid) {
                alert("Operação realizada com sucesso!");
            }
            else {
                alert(jsonResult.errorMessage);
            }
        }
    });
};