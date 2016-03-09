

  $(function() {
      $("#datepicker").datepicker({
          dateFormat: 'dd.mm.yy'
      });

  });
$(function() {
    $("#datepicker_end").datepicker({
        dateFormat: 'dd.mm.yy'
    });

});

function FilterValidate() {

    alert("error");

}


$(document).ready(function () {

    //$('#submit_filter').click(function () {
    //    //e.preventDefault();
    //    var begin = $('#datepicker').val();
    //    var end = $('#datepicker_end').val();
      
    //    $('#myPartialViewContainer').load('@Url.Action("FilterRegister", "Register")?begin=' + begin + '&end=' + end);
    //});

   // $('#refresh').bind('click', RefreshRegisters);
});


function RefreshRegisters() {
            $.ajax({
                url: '/Register/FilterRegister',
                type: 'POST',
                data: '{ '
                + '"begin" : "' + $('#datepicker').val() + '", '
                + '"end" : "' + $('#datepicker_end').val() + '" '
                + '} ',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                error: function (xhr) {
                    error = xhr;
                    alert('Error: ' + xhr.text);                   
                },
                success: function (result) {                                     
                       // alert('Status Ok: ' + result);                       
                    //===============================================================================
                    //Оновлення таблиці видатків записами отриманими через Ajax+jQuery
                    //===============================================================================
                        var row = "";
                        $.each(result, function (index, item) {
                            var cmnt = item.Comments == null ? "" : item.Comments;
                            row += "<tr><td>" 
                                + item.Id + "</td><td>" 
                                + item.Register_Category + "</td><td>" 
                                + item.Register_Type + "</td><td>" 
                                + item.Register_Balance + "</td><td>" 
                                + item.Register_Bill + "</td><td>" 
                                + Date.parse(item.Register_Date) + "</td><td>" 
                                + cmnt + "</td><td>"
                                + "<p><a href=\"/Home/RegisterDelete/@item.Id\">Localized text</a></p>"
                                + "</td></tr>";
                        });
                        $("#registerlist").html(row);
                    //===============================================================================
                   // $("#myPartialViewContainer").html("/Home/Index  ");
                    
                    //location.reload();

                 },
                async: true,
                processData: false
            });             
}

