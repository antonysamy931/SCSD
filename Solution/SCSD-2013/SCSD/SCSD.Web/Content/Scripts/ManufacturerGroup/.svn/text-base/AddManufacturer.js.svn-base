
$(function () {

    loadManufacturerList();
    $("#search").on("click", function (e) {
        e.stopPropagation();
        loadManufacturerList();
    });

    $("#save").on("click", function (e) {
        e.stopPropagation();
        saveData();
    });

});

function loadManufacturerList() {

    var manufacturerGroupId = $("#groupID").text();
    var searchKey = $("#searchKey").val()+"";
    if (searchKey.trim().length==0)
    {
        searchKey = " ";
    }

    $.ajax({

        type: 'post',
        url: '/ManufacturerGroup/GetManufacturers/',
        data: { 'manufacturerGroupId': manufacturerGroupId, 'searchKey': searchKey },
        datatype: "Json",
        cache: false,
        async: false,
        success: function (data) {

            if (data == "") {
               // $("#errorMsg").text("No Records Found..!");
            }
            else {
                populateData(data);
               // $("#errorMsg").text("No Records Found..!");
            }
            
        }
    });

}

function populateData(data) {

    if (data.error) {
        return;
    }

    $(".multiselect").empty();
    for (var i = 0, size = data.length; i < size; i++) {
        var item = data[i];
        $(".multiselect").append('<label><input value="' + item.Id + '" type="checkbox"><span>' + item.Name + '</span></label>');
        
    }
}


function saveData() {

    var manufacturerGroupID = $("#groupID").text();
    var manufacturerIDs = [];

    $(".multiselect input[type=checkbox]:checked").each(function (index) {

            var manufacturerId = $(this).val();     
            manufacturerIDs.push(manufacturerId);  
       
    });

    jQuery.ajaxSettings.traditional = true;

    $.ajax({

        type: 'post',
        url: '/ManufacturerGroup/AssignManufacturerToGroup/',
        data: { 'manufacturerGroupID': manufacturerGroupID, 'manufacturerIDs': manufacturerIDs },
        cache: false,
        async: false,
        success: function (data) {
               
            if (data.error) {

                return;
            }
            else if(data == "Success") {

                $(".multiselect input[type=checkbox]:checked").each(function (index) {
                    $(this).parent().remove();      // Removes mapped elements from search result screen
                });

            }

        }
    });

}
