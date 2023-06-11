$(function () {
    
    $("#donaciones").click(function (e) { 
        e.preventDefault();
        $("#valoraciones-page").fadeOut();
        $("#informacion-page").fadeOut();
        $("#contacto-page").fadeOut();
        $("#equipo-page").fadeOut();
        $("#dietas-page").fadeOut();
        $("#donaciones-page").fadeIn();
    });

    $("#valoraciones").click(function(e){
        e.preventDefault();
        $("#contacto-page").fadeOut();
        $("#donaciones-page").fadeOut();
        $("#informacion-page").fadeOut();
        $("#dietas-page").fadeOut();
        $("#equipo-page").fadeOut();
        $("#valoraciones-page").fadeIn();
        // updateValoraciones();
    });

    $("#informacion").click(function(e){
        e.preventDefault();
        $("#contacto-page").fadeOut();
        $("#donaciones-page").fadeOut();
        $("#valoraciones-page").fadeOut();
        $("#dietas-page").fadeOut();
        $("#equipo-page").fadeOut();
        $("#informacion-page").fadeIn();
    });

    $("#dietas").click(function(e) {
        e.preventDefault();
        $("#contacto-page").fadeOut();
        $("#dietas-page").fadeIn();
        $("#informacion-page").fadeOut();
        $("#donaciones-page").fadeOut();
        $("#valoraciones-page").fadeOut();
        $("#equipo-page").fadeOut();
    })

    $("#contacto").click(function(e){
        e.preventDefault();
        $("#contacto-page").fadeIn();
        $("#donaciones-page").fadeOut();
        $("#valoraciones-page").fadeOut();
        $("#informacion-page").fadeOut();
        $("#dietas-page").fadeOut();
        $("#equipo-page").fadeOut();
    })

    $("#equipo").click(function(e){
        e.preventDefault();
        $("#contacto-page").fadeOut();
        $("#donaciones-page").fadeOut();
        $("#valoraciones-page").fadeOut();
        $("#informacion-page").fadeOut();
        $("#dietas-page").fadeOut();
        $("#equipo-page").fadeIn();
    })

    // function updateValoraciones() {
    //     $.ajax({
    //         url: 'pagina_principal_en.php', // Replace with the actual PHP file that fetches the updated data
    //         type: 'GET',
    //         success: function (response) {
    //             $('#valoraciones-page').html(response);
    //         },
    //         error: function () {
    //             console.log('Error occurred while fetching valoraciones.');
    //         }
    //     });
    // }
});