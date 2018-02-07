$(function () {
    $(".deleteAlbum").click(function () {
        var albumid = $(this).attr("data-id");
        if (albumid != '') {
            if (confirm('Are you sure you want to delete record?')) {
                $.post("/MVC_MusicStore/StoreManager/delete/", { "id": albumid }, function (data) {

                    if (data){                                               
                        window.location.href = '/MVC_MusicStore/StoreManager/Index/';
                        alert("Record has been deleted successfully.");
                    }

                });

            }
        }
    });

    //$(".deleteAlbum").click(function () {

    //    $.ajax({
    //        url: '/en/myController/GetDataForInvoiceNumber',
    //        type: 'POST',
    //        data: JSON.stringify(requestData),
    //        dataType: 'json',
    //        contentType: 'application/json; charset=utf-8',
    //        error: function (xhr) {
    //            alert('Error: ' + xhr.statusText);
    //        },
    //        success: function (result) {
    //            CheckIfInvoiceFound(result);
    //        },
    //        async: true,
    //        processData: false
    //    });
    //});
});