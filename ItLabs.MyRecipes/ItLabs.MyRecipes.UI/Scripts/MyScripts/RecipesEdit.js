$('a[data-edit-href]').on('click', function () {
    debugger;
    var id = $(this).attr('data-edit-id');
    var url = $(this).attr('data-edit-href');
    $.get(url, function (data) {
        $('#ShowDetails-').html(data);
    });
})