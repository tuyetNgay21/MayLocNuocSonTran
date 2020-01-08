$('.CamOnMuaSanPham').click(function () {
    var idGioHang = $(this).data('id');
    var soluong = $('#'+idGioHang+'').val();
    if (idGioHang == undefined) {
        alert("Đã Sảy Ra lỗi");
    }
    else {
        $.ajax({
            type: 'Post',
            url: '/GioHang/addProduct',
            dataType: 'Json',
            data: {
                idGioHang: idGioHang
                ,soluong: soluong
            },
            success: function (e) {
                if (e == "1") {
                    alert("Đang Bảo Trì Hệ Thống");
                } else if (e == "2") {
                    alert("Kiếm Tra Lại Sản Phẩm");
                } else if (e == "3") {
                    alert("Chưa Đăng  Nhập Tài Khoản");
                    location.href = "/DangNhap/Log";
                } else if (e == "4") {
                    location.href="/DaMua/DangMua";
                } else {
                    alert("Đang Bảo Trì Hệ Thống");
                }

            },
            error: function () {
                alert("Đang Bảo Trì Hệ Thống");
            }


        });
    }
});

$('.HomNayDuocNghi').click(function () {
    var idGioHang = $(this).data('id');
    var soluong = $('#' + idGioHang + '').val();
    var gia = $(this).data('gia-id');
    var giamgia = $(this).data('giam-gia');
    var idSanPham = $(this).data('idsanpham');

    var congthuc = (((giamgia + 100) * gia) / 100) * soluong;
    $('#' + idSanPham + '').html(congthuc);
});

$('.XinLoiViBatKeLyDoGi').click(function () {
    var idGioHang = $(this).data('id');
    if (idGioHang == undefined) {
        alert("Đã Sảy Ra lỗi");
    }
    else {
        $.ajax({
            type: 'Post',
            url: '/GioHang/Deletes',
            dataType: 'Json',
            data: {
                idGioHang: idGioHang
            },
            success: function (e) {
                if (e == "1") {
                    alert("Đang Bảo Trì Hệ Thống");
                } else if (e == "2") {
                    alert("Kiếm Tra Lại Sản Phẩm");
                } else if (e == "3") {
                    alert("Chưa Đăng  Nhập Tài Khoản");
                    location.href = "/DangNhap/Log";
                } else if (e == "4") {
                    location.reload();
                } else {
                    alert("Đang Bảo Trì Hệ Thống");
                }

            },
            error: function () {
                alert("Đang Bảo Trì Hệ Thống");
            }


        });
    }
});