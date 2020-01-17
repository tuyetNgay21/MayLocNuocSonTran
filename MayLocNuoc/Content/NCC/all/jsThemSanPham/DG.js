$('#BTNTimBanGiVaSOSAo').click(function () {
    var PhanTrangChonBanGiDanhGia = $('#PhanTrangChonBanGiDanhGia').val();
    var PhanTrangChonSaoDanhGia = $('#PhanTrangChonSaoDanhGia').val();
    if (PhanTrangChonBanGiDanhGia == 'Hiển Thị số Bản Ghi' || PhanTrangChonSaoDanhGia == 'Hiển Thị số Sao') {
        alert('Cần Lựa Chọn Banr Ghi Và Số Sao');
    }
    else {

        location.href = '/NhaCungCap/Evaluate_Product?sao=' + PhanTrangChonSaoDanhGia + '&BanGi=' + PhanTrangChonBanGiDanhGia + '';

    }
});