$(function() {

    $(".mainDropdown").change(function (data) {
        var val = $(this).val();
       
        //window.history.replaceState("state", "title", "Home/Derivaciones")
        window.location.replace(val);

    })
});