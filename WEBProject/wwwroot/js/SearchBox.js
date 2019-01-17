// Used documents:
// http://api.jquery.com/
// https://www.w3schools.com/jquery/

$(document).ready(function () {

    $("#search_searchIcon_js").click(function () {
        $("#search_searchIcon_js").hide();
        $("#search_exitIcon_js").show();
        $("#search_content_js").show();
    });

    $("#search_exitIcon_js").click(function () {
        $("#search_exitIcon_js").hide();
        $("#search_searchIcon_js").show();
        $("#search_content_js").hide();
    });
});