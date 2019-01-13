// Used documents:
// http://api.jquery.com/
// https://www.w3schools.com/jquery/

var menuClick = true;

$(document).ready(function () {
    $(window).click(function (event) {
        if ($("#menu_js").is("#menu_js:visible") == true && menuClick == true) {
            $("#menu_js").hide();
        } else {
            menuClick = true;
        }
    });

    $("#menu_button_js").click(function () {
        $("#menu_js").toggle();
        menuClick = false;
    });

    $("#menu_content_js").click(function () {
        if (menuClick == null) {
            menuClick = true;
        } else {
            menuClick = false;
        }
    });

    $("#menu_exitMobile_js").click(function () {
        menuClick = null;
    });

    $("#menu_exitDesktop_js").click(function () {
        menuClick = null;
    });
});