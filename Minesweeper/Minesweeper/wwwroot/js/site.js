// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $(document).on("click", ".btn", function (event) {
        event.preventDefault();

        //Get the button number and then do a button update function that runs AJAX

        var buttonNumber = $(this).val();
        console.log(buttonNumber);
        ButtonUpdate(buttonNumber);
    });

    //run AJAX
    function ButtonUpdate(buttonNumber) {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: '/gameboard/RefreshButton',
            data: {
                "buttonNumber": buttonNumber
            },
            success: function (data) {
                console.log(data);
                $("#" + buttonNumber).html(data);
            }
        });
    }
});
