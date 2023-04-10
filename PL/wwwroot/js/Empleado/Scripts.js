
function ChangeStatus(idEmpleado, e) {
    var status = e.checked
    $.ajax({
        type: 'POST',
        url: 'ChangeStatus',
        dataType: 'json',
        data: { idEmpleado, status },
        success: {},
        error: function (ex) {
            alert('Error: ' + ex)
        }
    });
}

function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5274/Empleado/Add',
        data: empleado,
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalForm').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error al agregar el registro.');
        }
    });
};

function Update(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5274/Empleado/Update',
        data: empleado,
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalForm').modal('hide');

        },
        error: function (result) {
            alert('Error al agregar el registro.');
        }
    });
};

function GetById(idEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5274/Empleado/GetById?idEmpleado=' + idEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNombre').val(result.object.nombre);
            $('#txtApPaterno').val(result.object.apellidoPaterno);
            $('#txtApMaterno').val(result.object.apellidoMaterno);
            $('#status').val(result.object.status);

            $('#ModalForm').modal('show');
        },
        error: function () {
            alert('Error al mostrar la información');
        }
    });
}

function Enviar() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApPaterno').val(),
        ApellidoMaterno: $('#txtApMaterno').val(),
        Status: $('#status').val()
    }

    if (empleado.IdEmpleado == '') {
        empleado.Status = true;
        Add(empleado);
    }
    else {
        Update(empleado);
    }
}

function MostrarModal() {
    $('#ModalForm').modal('show');
    LimpiarModal();
}

function Delete(idEmpleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5274/Empleado/Delete?idEmpleado=' + idEmpleado,
        success: function () {
            $('#myModal').modal('show');
            $('#ModalForm').modal('hide');
        },
        error: function () {
            alert('Error al eliminar el registro.');
        }
    })
}

function LimpiarModal() {
    $('#txtIdEmpleado').val('');
    $('#txtNombre').val('');
    $('#txtApPaterno').val('');
    $('#txtApMaterno').val('');
}

function Reload() {
    location.reload();
}