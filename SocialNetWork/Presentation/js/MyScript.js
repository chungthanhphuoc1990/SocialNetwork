function checkAll() {
    $('.table tbody tr').each(function() {
        if ($('input#chkAll').is(":checked")) {
            $('input#chkList').attr({ 'checked': 'checked' });
            $('input#chkList').parent().parent().addClass('warning');
        } else {
            $('input#chkList').attr({ 'checked': false });
            $('input#chkList').parent().parent().removeClass('warning');
        }
    });
}

//Tool-tip
$(document).ready(function() {
    $(".btn").tooltip({ placement: 'bottom' });
    $(".pagesize").tooltip({ placement: 'top' });
    $(".gotoPage").tooltip({ placement: 'top' });
    $(".first").tooltip({ placement: 'top' });
    $(".prev").tooltip({ placement: 'top' });
    $(".next").tooltip({ placement: 'top' });
    $(".last").tooltip({ placement: 'top' });
    $(".form-control").tooltip({ placement: 'bottom' });
    $(".menu").tooltip({ placement: 'bottom' });
});

//-------------------Tooltip-------------------
function Tooltip(x) {
    $(x).tooltip({ toggle: 'tooltip' });
};
function TooltipA(x, position) {
    $(x).tooltip({ toggle: 'tooltip', placement: position });
};
//--------------------DatePicker--------------------
function DatePicker(id) {
    $(id).datepicker({
        showOn: "button",
        buttonImage: "../Images/calendar.gif",
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        buttonImageOnly: true
    });
    return false;
}

function DateTimePicker(id) {
    $(id).datetimepicker({
        showOn: "button",
        buttonImage: "../Images/calendar.gif",
        changeMonth: true,
        changeYear: true,
        buttonImageOnly: true
    });
    return false;
}

function MarkInputDay(id) {
    $(id).mask("99/99/9999"); //Kiem tra ngay nhap
    return false;
}

function MarkInputPhonePhoneTable(id) {
    $(id).mask("(99999) 999-999"); //Kiem tra so dien thoai 10 so
    return false;
}

function MarkInputPhone10(id) {
    $(id).mask("(9999) 999-999"); //Kiem tra so dien thoai 10 so
    return false;
}

function MarkInputPhone11(id) {
    $(id).mask("(99999) 999-999"); //Kiem tra so dien thoai 10 so
    return false;
}

function MarkInputCellPhone(id) {
    $(id).mask("(99999) 999-999"); //Kiem tra so dien thoai 10 so
    return false;
}

function MarkInputIDCode(id) {
    $(id).mask("999 999 999"); //Kiem tra so dien thoai 10 so
    return false;
}

function MarkInputDayTime(id) {
    $(id).mask("99:99"); //Kiem tra ngay nhap
    return false;
}
