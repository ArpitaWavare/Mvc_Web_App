$(document).ready(function () {
    debugger;
    Getalldata();
});



var Getalldata = function () {
    
    $.ajax({
        url: "/employee/Getalldata",
        method: "Post",
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblEmployee tbody").empty();
            $.each(response, function (index, elementValue) {
                html += 
                    "<tr><td>" + elementValue.Id +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Mobile_No +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.Address +
                    "</td></tr>";

            });
            $("#tblEmployee tbody").append(html);
        }
    });

}

var Getpostal = function () {
    debugger;
    var pincode = $("#txtpin").val();
    $.ajax({
        url: "/employee/Getpostal?pincode=" + pincode,
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblpostal tbody").empty();
            $.each(response, function (index, elementvalue) {
                html += "<tr><td>" + elementvalue.PostOffice[1].Name +
                    "</td><td>" + elementvalue.PostOffice[1].Description +
                    "</td><td>" + elementvalue.PostOffice[1].BranchType +
                    "</td><td>" + elementvalue.PostOffice[1].DeliveryStatus +
                    "</td><td>" + elementvalue.PostOffice[1].District +
                    "</td><td>" + elementvalue.PostOffice[1].Circle +
                    "</td><td>" + elementvalue.PostOffice[1].Division +
                    "</td><td>" + elementvalue.PostOffice[1].Region +
                    "</td><td>" + elementvalue.PostOffice[1].Block +
                    "</td><td>" + elementvalue.PostOffice[1].State +
                    "</td><td>" + elementvalue.PostOffice[1].Country +
                    "</td><td>" + elementvalue.PostOffice[1].Pincode +
                    "</td></tr>";
            });
            $("#tblpostal tbody").append(html);
        },
    });
}