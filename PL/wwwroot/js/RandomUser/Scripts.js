
function GetRandomUser() {
    $.ajax({
        type: 'GET',
        url: 'https://randomuser.me/api/',
        dataType: 'json',
        success: function (result) {
            var fila =
            "<tr>" +
                "<td class='text-center'>" + result.results[0].name.title + ". " + result.results[0].name.first +
                " " + result.results[0].name.last + "</td>" +
                "<td class='text-center'>" + result.results[0].email + "</td>" + 
                "<td class='text-center'>" + result.results[0].location.country + ", " +
                result.results[0].location.state + ", " + result.results[0].location.city + "</td>" + 
                "<td class='text-center'>" + result.results[0].gender + "</td>" + 
                "<td class='text-center'><img src='" + result.results[0].picture.large + "'></img></td>" + 
            "</tr>"

            $("#tblUsers tbody").append(fila);
        },
        error: function (ex) {
            alert('Error al realizar la consulta: ' + ex);
        }
    });
}


function LimpiarTabla() {
    $('#tblUsers tbody').empty();
}