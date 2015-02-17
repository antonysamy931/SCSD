

function IsUniqueCode() {
    var Code = $('#Code').val();
    if (Code != null) {
        $.ajax({
            url: "/ManufacturerGroup/IsGroupCodeUnique?code=" + Code,
            type: 'POST',
            cache: false,
            async: false,
            success: function (result) {
                if (!result.error) {
                    if (result.data.toLowerCase() === "true") {
                        $("#isCodeExist").text("Code Already Exists ");

                    }
                    else {
                        $("#isCodeExist").text("Can use this Code");

                    }
                }
                else {
                    alert(result.message);
                }
                
                return false;
            },
            error: function (e) {
                var u = e;
            }

        });
    }
}


function toggleStatus(value) {
    if (value.checked) {
        $("#statusName").text("Active");
        $('#Status').prop('checked', true);
    }
    else {
        $("#statusName").text("Inactive");
        $('#Status').prop('checked', false);
    }
}