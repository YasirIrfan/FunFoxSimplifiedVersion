
function showAddNewClassModal() {
    $('#NewEmployeeModal').modal('show');
}
$("#btnClassSearch").click(function (e) {
    e.preventDefault();
    var form = $("#ClassSearchForm");
    form.validate();
    /* if (form.valid()) {*/
    PlanetSearch();
    //}
});
function PlanetSearch() {
    ShowLoading();
    var plantSearchCriteria = FormDataToJSON(document.getElementById("ClassSearchForm"));
    $.ajax({
        type: 'POST',
        url: '/Class/ClassSearch',
        data: { plantSearch: plantSearchCriteria },
        success: function (result) {
            $("#divPlantResponse").html(result);
            $('#classTable').DataTable({
                "searching": false,
                "ordering": false,
                "filter": false,
                "lengthChange": false
            });
            $("body").tooltip({ selector: '[data-toggle=tooltip]' });
            setTimeout(function () {
                EndLoading();
            }, 500);
        },
        error: function () { EndLoading(); }
    });
}