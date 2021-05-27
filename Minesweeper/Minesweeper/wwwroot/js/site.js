var toggle = document.getElementById("theme-toggle");

var storedTheme = localStorage.getItem('theme') || (window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light");
if (storedTheme)
    document.documentElement.setAttribute('data-theme', storedTheme)


toggle.onclick = function () {
    var currentTheme = document.documentElement.getAttribute("data-theme");
    var targetTheme = "light";

    if (currentTheme === "light") {
        targetTheme = "dark";
    }

    document.documentElement.setAttribute('data-theme', targetTheme)
    localStorage.setItem('theme', targetTheme);
};



$(function () {

    $(document).on("mousedown", ".btn", function (event) {
        event.preventDefault();

        switch (event.which) {
            case 1:
                var buttonNumber = $(this).val();
                ButtonClick(buttonNumber, '/gameboard/RefreshButton' );
                break;
            case 2:
                alert("middleMouse click");
                break;
            case 3:
                var buttonNumber = $(this).val();
                ButtonClick(buttonNumber, '/gameboard/FlagButton');
                break;
            default:
                alert("unknown click");
        }
    });

    //run AJAX

    function ButtonClick(buttonNumber, AjaxUrlSrc) {
        $.ajax({
            datatype: "json",
            method: 'POST',
            url: AjaxUrlSrc,
            data: {
                "buttonNumber": buttonNumber
            },
            success: function (data) {
                console.log(data);
                $("#" + buttonNumber).html(data);
            }
        });
    }



    //Disable uses from acessing the right click menu

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
    });
});
