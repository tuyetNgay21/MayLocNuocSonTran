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