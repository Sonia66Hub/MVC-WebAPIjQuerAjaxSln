var mydata = null;
$(document).ready(function () {
    getData();
})

function getData() {
    $.ajax({
        type: 'GET',
        url: 'api/Person/',
        success: function (data) {
            $('#info').empty();
            $.each(data, function (key, val) {
                $('<tr>' + '<td>' + val.Name + '</td>' + '<td>' + val.Email + '</td>' +
                    '<td> <button onclick="editItem(' + val.Id + ')">Ediit</button>&nbsp;&nbsp' +
                    '<button onclick="deleteItem(' + val.Id + ')">Delete</button>' + '</td>' +
                    '<tr/>').appendTo($('#info'));
            });
            mydata = data;
        }
    })
}

function deleteItem(id) {
    $.ajax({
        type: "DELETE",
        url: "api/Person/" + id,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            getData();
        }
    })
}

$('#btnAdd').click(function () {
    var id = $("#id").val();
    var name = $("#name").val();
    var email = $("#email").val();
    $.ajax({
        type: "POST",
        url: "api/Person/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ name, email }),
        dataType: "JSON",
        success: function (data) {
            getData();
            $("#id").val('');
            $("#name").val('');
            $("#email").val('');   
        }
    })

})

function editItem(id) {
    $.each(mydata, function (key, item) {
        if (item.Id == id) {
            $("#name").val(item.Name);
            $("#email").val(item.Email);
            $("#id").val(item.Id);
        }
    })
}

$('#btnUpdate').click(function () { 
    var id = $("#id").val();
    var name = $("#name").val();
    var email = $("#email").val();
    $.ajax({
        type: "PUT",
        url: "api/Person/"+ id,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ name, email, id }),
        dataType: "JSON",
        success: function (data) {
            getData();
            $("#id").val('');
            $("#name").val('');
            $("#email").val('');
        }
    })
})