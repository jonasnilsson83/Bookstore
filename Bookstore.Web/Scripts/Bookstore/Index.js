//$(document).ready(function () {
//    //$('a').click(function (event) {
//    //    event.preventDefault();
//    //    $(this).hide("slow");
//    //});
//    alert('hi');
//});




//(function () {

//    var buttonSelector = ".SearchGroup button";
//    var inputSelector = ".SearchGroup input";
//    var url = "http://localhost:54792/Bookstore/SearchForBooks";

//    $(buttonSelector).click(function () {

//        $.ajax({
//            type: "GET",
//            dataType: "json",
//            //data: JSON.stringify($(inputSelector).val()),
//            //data: $(inputSelector).val(),
//            data: "searchString=" + $(inputSelector).val() ,
//            url: url,
//            contentType: "application/json; charset=utf-8",

//            success: function (result) {
//                alert('succes');
//            },
//            error: function (result) {
//                alert('error');
//            },
//            failure: function (result) {
//                alert('failure');
//            }



//        });
//    });

//})();