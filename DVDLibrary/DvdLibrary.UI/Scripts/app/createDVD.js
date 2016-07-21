

$().ready(function () {
    // on button click, show modal
    $('#btnShowAddDVD').click(function () {
        $('#addDVDModal').modal('show');
    });

    $('#btnSaveDVD').click(function () {
        var dvd = {};

        dvd.Title = $("#title").val();
        dvd.DirectorName = $("#directorname").val();
        dvd.ReleaseDate = $("#releasedate").val();
        dvd.MPAARating = $("#mpaarating").val();
        dvd.Studio = $("#studio").val();
        dvd.UserRating = $("#userrating").val();
        dvd.UserNotes = $("#usernotes").val();
        dvd.Actors = $("#actors").val();

        $.ajax({
            url: '/api/dvd',
            data: dvd,
            //```{
            //        Title: $("#title").val(), DirectorName: $("#directorname").val(), ReleaseDate: $("#releasedate").val(), MPAARating: $("#mpparating").val(),
            //        Studio: $("#studio").val(), UserRating: $("#userrating").val(), UserNotes: $("#usernotes").val(), Actors: $("#actors").val()
            //    },
            //data: $("#myform").serialize()
            method: "POST"
        });

        $.post(uri, dvd)
            .done(function (data) {
                LoadDVDList();
                $("#addDVDModal").modal('hide')
            })
            .fail(function (jqXHR, status, err) {
                alert(status + " - " + err);
            })
    });
});