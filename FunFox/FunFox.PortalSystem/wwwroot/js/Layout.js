$(document).ready(function () {
    ShowLoading();
});
window.addEventListener("DOMContentLoaded", function () {
    overrideLoading = setTimeout(function () {
        EndLoading();
    }, 1000); //Delay just used for example and must be set to 0.
});

function ShowLoading() {
    $("#waitContainer").css("display", "block")
}

function EndLoading() {
    $("#waitContainer").css("display", "none")
}
function FormDataToJSON(FormElement) {
    var formData = new FormData(FormElement);
    var ConvertedJSON = {};
    for (const [key, value] of formData.entries()) {
        if (typeof (value) == "string") {
            ConvertedJSON[key] = value.trim();
        }
    }

    return ConvertedJSON
}