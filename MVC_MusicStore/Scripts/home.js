$(function () {
   /* $(".genreName").click(function () {
        var genrename = $(this).attr("data-id");

        if (genrename != '') {

            $.get("/MVC_MusicStore/Store/Browse", { "Genre": genrename }, function (data)
            { 
                if (data) { 
                    $('#promotion').html('');
                    $('#promotion').html(data);

                } 
            });
        }
    }); */

    $(".genreName").click(function (e) {

        var genrename = $(this).attr("data-id");
        var requestData = { "Genre": genrename };

        $.ajax({
            url: '/MVC_MusicStore/Store/Browse',
            type: 'GET',
            data: requestData,
            dataType: '',
            contentType: '',
            error: function (xhr) {
                alert('Error: ' + xhr.statusText);
            },
            success: function (result) {
                $('#promotion').remove();
                $('#promotionNew').remove();
                $("#main").prepend("<div id='promotionNew' class='row'>" + result+"</div>");
            } 
        });

        e.preventDefault();

    });

    
    // Document.ready -> link up remove event handler
    $(".RemoveLink").click(function (e) {
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");

        if (recordToDelete != '') {

            // Perform the ajax post
            $.post("ShoppingCart/RemoveFromCart", { "id": recordToDelete },
                function (data) {
                    // Successful requests get here
                    // Update the page elements
                    if (data.ItemCount == 0) {
                        $('#row-' + data.DeleteId).fadeOut('slow');
                    } else {
                        $('#item-count-' + data.DeleteId).text(data.ItemCount);
                    }

                    $('#cart-total').text(data.CartTotal);
                    $('#update-message').text(data.Message);
                    $('#cart-status').text('Cart (' + data.CartCount + ')');
                });
        }
    }); 


    function handleUpdate() {
        // Load and deserialize the returned JSON data
        var json = context.get_data();
        var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

        // Update the page elements
        if (data.ItemCount == 0) {
            $('#row-' + data.DeleteId).fadeOut('slow');
        } else {
            $('#item-count-' + data.DeleteId).text(data.ItemCount);
        }

        $('#cart-total').text(data.CartTotal);
        $('#update-message').text(data.Message);
        $('#cart-status').text('Cart (' + data.CartCount + ')');
    }

    $(".freshAlbum").mouseover(function (e) {
        var albumId = $(this).attr("data-id");
        var requestData = { "id": albumId };
        $.ajax({
            url: '/MVC_MusicStore/api/Album',
            type: 'GET',
            data: requestData,
            dataType: 'json',
            contentType: '',
            error: function (xhr) {
                alert('Error: ' + xhr.statusText);
            },
            success: function (result) {
                alert(result.AlbumName);
            }
        });

        e.preventDefault();
    });

});