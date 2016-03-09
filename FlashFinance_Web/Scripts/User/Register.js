

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
    $('#submit_filter').click(function (e) {
        e.preventDefault();
        var begin = $('#datepicker').val();
        var begin = $('#datepicker_end').val();
      
        $('#row_registers').load('@Url.Action("FilterRegister", "Register")?begin=' + begin + '&end=' + end);
    });
});

