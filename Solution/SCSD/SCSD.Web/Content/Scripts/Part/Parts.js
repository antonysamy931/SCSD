/// <reference path="../jquery-1.11.2.min.js" />
var globalPartId;
$(document).ready(function () {

    //Create part screen
    $('#overWeightCheckbox').click(function () {
        if ($(this).prop('checked')) {
            $('#overWeight').text('Yes');
        }
        else {
            $('#overWeight').text('No');
        }
    });

    //Edit part screen
    $('#editForm input[type=text]').each(function () {
        if ($(this).val() === '0') {            
            $(this).val('');
        }
    });

    $('#overWeightCheckbox_edit').click(function () {
        if ($(this).prop('checked')) {
            $('#overWeight_edit').text('Yes');
        }
        else {
            $('#overWeight_edit').text('No');
        }
    });

    //Search part screen
    $('#SearchParts').click(function () {
        var partSearchVal = $('#corePartsSearch').val();
        var pageSize = $('#view').val();
        GridRequest(partSearchVal, 1, pageSize);
    });

});

/*Part Search function start*/
function PageSizeChange(size) {
    var partSearchVal = $('#corePartsSearch').val();
    var pageSize = $(size).val();
    GridRequest(partSearchVal, 1, pageSize);
}

function FirstPage(firstPage, pageSize) {
    var partSearchVal = $('#corePartsSearch').val();
    GridRequest(partSearchVal, firstPage, pageSize);
}

function LastPage(lastPage, pageSize) {
    var partSearchVal = $('#corePartsSearch').val();
    GridRequest(partSearchVal, lastPage, pageSize);
}

function PreviousPage(prePage, pageSize) {
    var partSearchVal = $('#corePartsSearch').val();
    GridRequest(partSearchVal, prePage, pageSize);
}

function NextPage(nextPage, pageSize) {
    var partSearchVal = $('#corePartsSearch').val();
    GridRequest(partSearchVal, nextPage, pageSize);
}

function Page(pageNo, pageSize) {
    var partSearchVal = $('#corePartsSearch').val();
    GridRequest(partSearchVal, pageNo, pageSize);
}

function GridRequest(searchText, pageNo, pageSize) {
    $.ajax({
        url: '/Part/ListData?searchText=' + searchText + '&pageNo=' + pageNo + '&pageSize=' + pageSize,
        type: 'GET',
        dataType: 'HTML',
        success: function (data) {
            $('#ListGrid').html(data);
        },
        error: function (e) {
            //$('#ListGrid').html(e.responseText);
        },
        async: false
    });
}

function GetCorePart(partId) {
    $.ajax({
        url: '/Part/GetCorePart?PartId=' + partId,
        type: 'POST',
        dataType: 'JSON',
        success: function (data) {
            if (!data.error) {
                $('#partImage').attr('src', '/Part/GetPartImage?GraphicId=' + data.data.GraphicId);

                if (data.data.Name.length < 30) {
                    $('#partName').text(data.data.Name);
                    $('#partName').attr('title', data.data.Name);
                    $('#partName').css('cursor', 'pointer');
                }
                else {
                    var name = data.data.Name.substr(0, 27) + "...";
                    $('#partName').text(name);
                    $('#partName').attr('title', data.data.Name);
                    $('#partName').css('cursor', 'pointer');
                }

                $('#imageType').text('2D');
                $('#partCode').text(data.data.Code);
                $('#partNumber').text(data.data.OemPartNo);
                $('#catalogNumber').text(data.data.CatalogNo);
                $('#manufacturersCount').text(data.data.ManufacturerCount);
                $('#fieldServiceCompanyCount').text(data.data.FSCCount);
                $('#stockiestCount').text(data.data.StockiestCount);
                $('#preview').modal('show');
            }
        },
        error: function (e) {
        },
        async: false
    });
}

function EditPart(partId,checkbox) {
    $('#ListGrid table tbody tr td input[type=checkbox]').not($(checkbox)).removeAttr('checked');    
    globalPartId = partId;
}

function EditScreen() {
    if (typeof (globalPartId) !== 'undefined') {
        window.location.replace("/Part/Edit?PartId=" + globalPartId);
    }
}
/*Part Search function end*/