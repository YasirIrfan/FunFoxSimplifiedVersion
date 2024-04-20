$("#btnPlantSearch").click(function (e) {
    e.preventDefault();
    var form = $("#PlantSearchForm");
    form.validate();
   /* if (form.valid()) {*/
        PlanetSearch();
    //}
});
function PlanetSearch() {
    ShowLoading();
    var plantSearchCriteria = FormDataToJSON(document.getElementById("PlantSearchForm"));
    $.ajax({
        type: 'POST',
        url: '/Plant/PlantsSearch',
        data: { plantSearch: plantSearchCriteria },
        success: function (result) {
            $("#divPlantResponse").html(result);
            $('#plantTable').DataTable({
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