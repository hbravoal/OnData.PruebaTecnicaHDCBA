
$(document).ready(function () {
    $(function () {
        var scntDiv = $('#dynamicDiv');
        $(document).on('click', '#addInput', function () {

            $.ajax({
                type: 'POST',
                url: Url,
                dataType: 'json',                
                success: function (teams) {
                    $('<select class="form-control valid"  id="Categories2" ></select>   <a class="btn btn-danger" href="javascript:void(0)" id="remInput">' +
                    '<span class="glyphicon glyphicon-minus" aria-hidden="true"></span> ' +
                    'Remover Campo' +
                '</a>').appendTo(scntDiv);
                    $.each(teams, function (i, item) {                        
                        $("#Categories2").append('<option value="'
                        + item.id + '">' +
                        item.name + '</option>' );
                        
                        
                        
                    });
                }, error: function (ex) {
                    alert('Failed to retrieve Teams.' + ex);
                }
            }); return false;

            
            $(document).on('click', '#remInput', function () {
                $(this).parents('p').remove();
                return false;
            });   
    });
    });
});