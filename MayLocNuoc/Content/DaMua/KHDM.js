$('.xoaDaMua').click(function () {
    var idDm = $(this).data('id');
    if (idDm == undefined || idDm == "") {
        alert("Có Lỗi Hệ Thống");
    }
    else {
        $.ajax({
            type: 'Post',
            url: '/DaMua/XoaSanPhamDaMua',
            dataType: 'Json',
            data: { id: idDm },
            success: function (e) {
                if (e == "1") {
                    alert("Hệ Thống Đang Bị Lỗi");
                }
                else if (e == "2") {
                    alert("Đang Vận Chuyển Không Thể Hủy");
                }
                else if  (e == "3")
                {
                    alert("Đã Hủy Thành Công Cảm Ơn Quý Khách Đã Sử Dụng Dịch Vụ Của Chúng Tôi ");
                    location.reload();
                }
            },
            error: function (e) {
                alert("Có Lỗi hệ thống");
            }
        });
    }
});

$('.KhoiPhucDaXoa').click(function () {
    var idDm = $(this).data('id');
    if (idDm == undefined || idDm == "") {
        alert("Có Lỗi Hệ Thống");
    }
    else {
        $.ajax({
            type: 'Post',
            url: '/DaMua/SanPhamDaXoaCanKhoiPhuc',
            dataType: 'Json',
            data: { id: idDm },
            success: function (e) {
                if (e == "1") {
                    alert("Hệ Thống Đang Bị Lỗi");
                }
                else if (e == "2") {
                    alert("Đang Vận Chuyển Không Thể Hủy");
                }
                else if (e == "3") {
                    alert("Đã Khôi Phục Thành Công Cảm Ơn Quý Khách Đã Sử Dụng Dịch Vụ Của Chúng Tôi ");
                    location.reload();
                }
            },
            error: function (e) {
                alert("Có Lỗi hệ thống");
            }
        });
    }
});

$('#Shearch_Name_Product').click(function () {
    var idDm = $('#value_shearch_Product').val();
        location.href = '/DaMua/Shearch?id='+idDm+'';
});