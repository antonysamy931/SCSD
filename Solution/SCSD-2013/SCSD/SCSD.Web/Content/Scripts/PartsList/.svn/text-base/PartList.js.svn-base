
var globalPartsListId;
$(document).ready(function()
{


    //Edit partlist screen
    $('#editForm input[type=text]').each(function () {
        if ($(this).val() === '0') {
            $(this).val('');
        }
    });

    $('#PartsListStatusCheckbox_edit').click(function () {
        if ($(this).prop('checked')) {
            $('#PartsListStatus_edit').text('Active');
        }
        else {
            $('#PartsListStatus_edit').text('Inactive');
        }
    });

});



function EditPart(id, checkbox) {
    $('#ListGrid table tbody tr td input[type=checkbox]').not($(checkbox)).removeAttr('checked');
    alert(globalPartsListId);
    globalPartsListId = id;
}

function EditScreen() {
    if (typeof (globalPartsListId) !== 'undefined') {
        alert(globalPartsListId);
        window.location.replace("/PartsList/Edit?id=" + globalPartsListId);
    }
}