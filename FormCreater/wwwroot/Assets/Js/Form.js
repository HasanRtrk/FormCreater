$(function () {

    $(".btnSetForm").click(function () {
        $.ajax({
            type: 'POST',
            url: '/Form/AddForm',
            data: { formDesc: $("#txtFormDesc").val(), formName: $("#txtFormName").val(), userName: $("#userName").val(), firstColumn: $("#txtFirstColumn").val(), secondColumn: $("#txtSecondColumn").val(), thirdColumn: $("#txtThirdColumn").val() },
            dataType: "Json",
            success: function () {
                $('#setForm').modal('hide');
                Swal.fire({
                    title: "Form basarili bir sekilde kaydedildi.",
                    confirmButtonText: "Tamam"
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                })
            }
        });
    });

    $(".btnFormSil").click(function () {
        var silinenFormId = $(this).attr("formId");

        Swal.fire({
            title: silinenFormId + " Id'li form silinecek onayliyor musunuz?",
            showCancelButton: true,
            confirmButtonText: `Sil`,
            cancelButtonText: `Ýptal`
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'Json',
                    url: '/Form/DeleteForm',
                    data: { Id: silinenFormId },
                    success: function () {
                        Swal.fire({
                            title: silinenFormId + " Id'li form silindi.",
                            confirmButtonText: "Tamam"
                        }).then((result) => {
                            if (result.isConfirmed) {
                                location.reload();
                            }
                        })
                    },
                    error: function () {
                        Swal.fire(formId + " Id'li form silinirken bir hata olustu.", '', error);
                    }
                });
            }
        });


    })








    $('.btnShowFormModal').click(function () {
        var formId = $(this).attr("formId");
        if (formId == undefined) {
            $("#lblFormId").html("");
            $("#txtFormName").val("");
            $("#txtFormDesc").val("");
            $("#txtFirstColumn").val("");
            $("#txtSecondColumn").val("");
            $("#txtThirdColumn").val("");
        }
        else {
            $("#lblFormId").html($(this).attr("formId"));
            $("#txtFormName").val($(this).attr("formName"));
            $("#txtFormDesc").val($(this).attr("formDesc"));
            $("#txtFirstColumn").val($(this).attr("firstColumn"));
            $("#txtSecondColumn").val($(this).attr("secondColumn"));
            $("#txtThirdColumn").val($(this).attr("thirdColumn"));
        }
        $('#setForm').modal('toggle');

    })





















});