// Used documents:
// http://api.jquery.com/
// https://www.w3schools.com/jquery/

var menu = true;

$(document).ready(function () {
    $(window).click(function () {
        if ($("#menu_js").is("#menu_js:visible") == true && menu == true) {
            $("#menu_js").hide();
        } else {
            menu = true;
        }
    });

    $("#menu_button_js").click(function () {
        $("#menu_js").toggle();
        menu = false;
    });

    $("#menu_content_js").click(function () {
        menu = false;
    });
});