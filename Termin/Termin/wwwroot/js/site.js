// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(function () {
    RefreshContact();   
    var placeholderElement = $('#modal-placeholder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        // url to Razor Pages handler which returns modal HTML

        var url = $(this).data('url');
        console.log(url);
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });


    function RefreshContact() {
        var contactPlaceholder = $('#allContacts-placeholder');
        console.log(window.location.href);
        var url = window.location.href + '&handler=AllContacts';
        $.get(url).done(function (data) {
            console.log(data);
            contactPlaceholder.html(data);
        })
    };

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            // replace modal contents with new form
            placeholderElement.find('.modal-body').replaceWith(newBody);

            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
                RefreshContact();
            }
        });

    });
});