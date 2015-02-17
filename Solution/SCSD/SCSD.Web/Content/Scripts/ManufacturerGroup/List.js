$(function () {

    var firstPage = 1;

    loadGrid(firstPage);  // Loads grid on page load
    loadPagination(loadGrid);  // Assigining for Call back from Pagination.js

    $("#searchGroups").on('click', function (e) {
        e.preventDefault();
        loadGrid(firstPage);
    });

    function loadGrid(currentPage) {
        
        var searchText = $('#manSearch').val().trim();
        if (searchText.length == 0) {
            searchText = " ";
        }

        var recordsPerPage = $('#recordsPerPage').val();

        $.ajax({
            type: 'GET',
            url: '/ManufacturerGroup/SearchList',
            data: { searchText: searchText, recordsPerPage: recordsPerPage, currentPage: currentPage },
            cache: false,
            async: false,
            success: function (result) {
                $("#searchList").html(result);
                if (result.indexOf("No records") == -1) {
                    $("#recordsPerPageRow").show();
                }
                else {
                    $("#recordsPerPageRow").hide();
                }
            }
        });
    }


    $("#searchList").on("click", ".preview", function () {
         
        var $record = $(this).closest('tr');
        var name = $record.find(".mgName").attr("title");
       
        if (name.length < 30) {
            $('#mgName').text(name);
        }
        else {
            var shortName = name.substr(0, 27) + "...";
            $('#mgName').text(shortName);
        }

        $('#mgName').attr('title', name);
        $('#mgName').css('cursor', 'pointer');

        var code = $record.find(".mgCode").text().trim();
        var count = $record.find(".mgCount").text().trim();
        var status = ($record.find(".mgStatus").text());
        var createdOn =$record.find(".mgCreatedAt input").val();
        var createdBy = $record.find(".mgCreatedBy input").val();

        $("#mgCode").text(code);
        $("#mgStatus").text(status);
        $("#mgCreatedBy").text(createdBy);
        $("#mgCreatedOn").text(createdOn);
        $("#manufacturesCount").text(count);

        // Show modal popup
        $('#preview').modal({
            show: true
        });

    });

    $("#searchList").on("click", "input[type=checkbox]", function () {
       
        $("#searchList").on("click", "input[type=checkbox]", function () {

            var countOfCheckedCheckBoxes = $("input[type=checkbox]:checked").length;
            if (countOfCheckedCheckBoxes > 1) {
                $(this).attr("checked", false)
                alert("Uncheck selected record to select another record");
            }

        });
    });

    $("#manage").on("click", function () {

        var countOfCheckedCheckBoxes = $("input[type=checkbox]:checked").length;

        if (countOfCheckedCheckBoxes < 1) {
            alert("Select record to manage");
        }
        else {
            debugger;
            var manfacturerGroupId = $("input[type=checkbox]:checked").closest('tr').find("span#manGrpID input").val();
            var manufacturerGroupName = $("input[type=checkbox]:checked").closest('tr').find(".mgName").text().trim();
            window.location.replace('/ManufacturerGroup/Manage?manufacturerGroupID=' + manfacturerGroupId + "&manufacturerGroupName=" + manufacturerGroupName);
        }
       
    });

});