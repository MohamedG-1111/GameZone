$(document).ready(function () {
    $('#Cover').on('change', function () {
        var previewContainer = $('#Cover-Preview');
        var previewImage = $('.cover-preview');
        var file = this.files[0];

        if (file) {
            var url = window.URL.createObjectURL(file);
            previewImage.attr('src', url);
            previewContainer.removeClass('d-none');
        } else {
            previewContainer.addClass('d-none');
        }
    });
});