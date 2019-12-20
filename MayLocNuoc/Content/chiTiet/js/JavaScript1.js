﻿$('#dangnhap112').click(function () {
    $('#submitDangNhap').css('display', 'block');
    $('#submitDangKy').css('display', 'none');
    $('#dkdc').css('display', 'none');
    $('#dkPassAgain').css('display', 'none');
    $('#tendc').css('display', 'none');
    $('#tuoidc').css('display', 'none');
    $('#emaildc').css('display', 'none');
});
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$('#dangky112').click(function () {
    $('#submitDangKy').css('display', 'block');
    $('#submitDangNhap').css('display', 'none');
    $('#dkdc').css('display', 'block');
    $('#dkPassAgain').css('display', 'block');
    $('#tendc').css('display', 'block');
    $('#tuoidc').css('display', 'block');
    $('#emaildc').css('display', 'block');
});
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$('#submitDangNhap').click(function () {
    var a = $('#dnsdt').val().trim();
    var b = $('#dnpass').val().trim();
    $.ajax({
        url: 'dangnhap1123',
        method: "POST",
        data: { a: a, b: b },
        Type: "json",
        success: function (e) {
            if (e != 0) {
               // location.reload();
            }
            else {
                alert("Tài Khoản Không Chính Xác");
            }
        },
        error: function () { alert('Có Lỗi sảy ra'); }
    });
});

function checkEmail() {
    var email = $('#emaildc').val();
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!filter.test(email)) {

        email.focus;
        return false;
    }
    else {
        return true;
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$('#submitDangKy').click(function () {
    var taikhoan = $('#dnsdt').val();
    var matkhau = $('#dnpass').val();
    var matkhauagain = $('#dkPassAgain').val();
    var diachi = $('#dkdc').val();
    var ten = $('#tendc').val();
    var tuoi = $('#tuoidc').val();
    var email = $('#emaildc').val();
    if (taikhoan === null || matkhau === null || matkhauagain === null ||
        diachi === null || ten === null || tuoi === null || email === null ||
        taikhoan === "" || matkhau === "" || matkhauagain === "" || diachi === "" ||
        ten === "" || tuoi === "" || email === "") {
        alert("Bạn Cần Nhập Thông Tin Đầy Đủ");
    }
    else {
        if (checkEmail() === false) {
            alert('Hay nhap dia chi email hop le.\nExample@gmail.com');
        } else {
            if (matkhau === matkhauagain) {
                $.ajax({
                    url: 'themtaikhoan',
                    method: "POST",
                    data: { a: taikhoan, b: matkhau, c: diachi, d: ten, e: tuoi, g: email },
                    Type: "json",
                    success: function (e) {
                        alert(e);
                    },
                    error: function () {
                        alert('Có Biến');
                    }
                });
            }
            else {
                alert('Mật Khẩu Không Giống Nhau');
            }
        }
    }


});
//nhan danh gia , 
//kiem tra so sao//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var abvcghs = 0;
$('#rating5').click(function () {
    abvcghs = $('#rating5').val();
});
$('#rating4').click(function () {
    abvcghs = $('#rating4').val();
});
$('#rating3').click(function () {
    abvcghs = $('#rating3').val();
});
$('#rating2').click(function () {
    abvcghs = $('#rating2').val();
});
$('#rating1').click(function () {
    abvcghs = $('#rating1').val();
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$("#danhgia112").click(function () {
    if (abvcghs == 0) {
        alert("Bạn Cần đánh giá số sao");
    }
    else {
        var noidung = $('#noidungdanhgia').val();
        var sosao = abvcghs;
        if (noidung == "" || noidung == null) {
            alert("Bạn Cần Nhập Nội dung");
        }
        else {
            $.ajax({
                url: 'themDanhGia',
                method: "POST",
                data: { a: noidung, b: sosao },
                Type: "json",
                success: function (e) {
                    if (e == "1") {
                       // location.reload();
                    }
                    else {
                        alert(e)
                    }
                },
                error: function () {
                    alert('Có Biến');
                }
            });
        }
    }

});
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$(".like").off().on('click', function () {
    var idcdg = this.id;
    
    $.ajax({
        url: 'themlikedg',
        method: "POST",
        data: { a: idcdg },
        Type: "json",
        success: function (e) {
            if (e === "1") {
              //  location.reload();
            }
            else if (e == "-2") {
                alert('Có Lỗi Sảy Ra');
            }
            else if (e == "0") {

            }
            else if (e == "-1") {
                alert("Bạn Cần Đăng Nhập");
            }
            else {
                alert(e)
            }
        },
        error: function () {
            alert('Có Biến');
        }
    });
});

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$(".butt").off().on('click', function () {
    var idcdg = this.id;
    
       var noi=$('.'+idcdg +'').val();
   $.ajax({
       url: 'themcommentdg',
        method: "POST",
        data: { a: idcdg , b:noi },
        Type: "json",
        success: function (e) {
            if (e === "1") {
             //   location.reload();
            }
            else if (e == "-2") {
                alert('Có Lỗi Sảy Ra');
            }
            else if (e == "-1") {
                alert("Bạn Cần Đăng Nhập");
            }
            else {
                alert(e)
            }
        },
        error: function () {
            alert('Có Biến');
        }
    });
});
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
