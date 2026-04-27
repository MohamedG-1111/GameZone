document.addEventListener("DOMContentLoaded", function () {

    const input = document.getElementById("ImageInput");
    const previewContainer = document.getElementById("Image-Preview");
    const previewImage = document.getElementById("PreviewImage");

    input.addEventListener("change", function (e) {

        const file = e.target.files[0];

        if (!file) {
            previewContainer.classList.add("d-none");
            previewImage.src = "";
            return;
        }

        if (!file.type.startsWith("image/")) {
            alert("Please select a valid image");
            input.value = "";
            previewContainer.classList.add("d-none");
            return;
        }

        const reader = new FileReader();

        reader.onload = function (e) {
            previewImage.src = e.target.result;
            previewContainer.classList.remove("d-none");
        };

        reader.readAsDataURL(file);
    });

});