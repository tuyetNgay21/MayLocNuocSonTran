$('#BTNthang').click(function () {
    var BTNChonThangNam = $('#BTNChonThangNam').val();
    var BTNChonThangThang = $('#BTNChonThangThang').val();
    if (BTNChonThangNam == 'Năm' || BTNChonThangThang == 'Tháng') {
        alert('Cần Lựa Chọn Tháng Năm');
    }
    else {

        location.href = '/NhaCungCap/Product_In_Day_inMonth/?thang=' + BTNChonThangThang + '&nam=' + BTNChonThangNam+'';
               
    }
});

$('#btnMap2').click(function () {
    var BTNChonThangNam = $('#btnnamMap2').val();
    var BTNChonThangThang = $('#btnthangMap2').val();
    var btnngayMap2 = $('#btnngayMap2').val();
    if (BTNChonThangNam == 'Năm' || BTNChonThangThang == 'Tháng') {
        alert('Cần Lựa Chọn Tháng Năm');
    }
    else {

        location.href = '/NhaCungCap/Product_In_Day_inMonth/?thang=' + BTNChonThangThang + '&nam=' + BTNChonThangNam + '&ngay=' + btnngayMap2 + '';

    }
});

$('#btnchitiet').click(function () {
    var BTNChonThangNam = $('#btnchitietnam').val();
    var BTNChonThangThang = $('#btnchitietThang').val();
    var btnngayMap2 = $('#btnchitietngay').val();
    if (BTNChonThangNam == 'Năm' || BTNChonThangThang == 'Tháng') {
        alert('Cần Lựa Chọn Tháng Năm');
    }
    else {

        location.href = '/NhaCungCap/Product_In_Day_inMonth/?thang=' + BTNChonThangThang + '&nam=' + BTNChonThangNam + '&ngay=' + btnngayMap2 + '';

    }
});