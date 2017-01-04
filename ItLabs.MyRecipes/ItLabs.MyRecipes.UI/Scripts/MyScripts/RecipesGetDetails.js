$('a[data-details-href]').on('click', function () {
    debugger;
    var id = $(this).attr('data-details-id');
    var url = $(this).attr('data-details-href');
    $.get(url, function (data) {
          $('#ShowDetails-').html(data);
    });
})