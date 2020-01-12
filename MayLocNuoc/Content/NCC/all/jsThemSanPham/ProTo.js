$('.DaLapDat').click(function () {
    var idcuano = $(this).data('id');
    var idsanpham = $(this).data('idcuasanpham');
    if (idcuano == undefined || idcuano == "") {
        alert('Có Sự cố rồi ');
    }
    else {
        $.ajax({
            type: 'post',
            url: '/NhaCungCap/daLapDat',
            dataType: 'Json',
            data: { idcuano: idcuano, idsanpham: idsanpham },
            success: function (e) {
                if (e == "1") {
                    alert("Có Lỗi Hệ Thống");
                }
                else if (e == "2") {
                    alert("Sản Phẩm Này Không Phải của bạn ");
                }
                else {
                    location.reload();
                }
            },
            error: function () {
                alert('Có Sự cố rồi ');
            }             
        });
    }
});

$('.DangVanChuyen').click(function () {
    var idcuano = $(this).data('id');
    var idsanpham = $(this).data('idcuasanpham');
    if (idcuano == undefined || idcuano == "") {
        alert('Có Sự cố rồi ');
    }
    else {
        $.ajax({
            type: 'post',
            url: '/NhaCungCap/dangVanChuyen',
            dataType: 'Json',
            data: { idcuano: idcuano, idsanpham: idsanpham },
            success: function (e) {
                if (e == "1") {
                    alert("Có Lỗi Hệ Thống");
                }
                else if (e == "2") {
                    alert("Sản Phẩm Này Không Phải của bạn ");
                }
                else {
                    location.reload();
                }
            },
            error: function () {
                alert('Có Sự cố rồi ');
            }
        });
    }
});


$('.thayDoiNgayThan').click(function () {
    var idcuano = $(this).data('id');
    var idsanpham = $(this).data('idcuasanpham');

    var ngay = $('.ngay').data('id', idcuano).val();
    var thang = $('.thang').data('id', idcuano).val();
    var nam = $('.nam').data('id', idcuano).val();

    if (idcuano == undefined || idcuano == "") {
        alert('Có Sự cố rồi ');
    }
    else {
        $.ajax({
            type: 'post',
            url: '/NhaCungCap/thayDoiNgayLapDat',
            dataType: 'Json',
            data: { idcuano: idcuano, idsanpham: idsanpham, ngay: ngay, thang:thang,nam,nam},
            success: function (e) {
                if (e == "1") {
                    alert("Có Lỗi Hệ Thống");
                }
                else if (e == "2") {
                    alert("Sản Phẩm Này Không Phải của bạn ");
                }
                else {
                    location.reload();
                }
            },
            error: function () {
                alert('Có Sự cố rồi ');
            }
        });
    }
});