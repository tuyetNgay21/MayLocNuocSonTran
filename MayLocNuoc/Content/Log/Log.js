//dang nhap cua log phan dang nhap cua ngươi mua hang
$("#btnLog_DanhNhap").click(function () {
    var taikhoan = $("#AccdanhNhap").val();
    var matKhau = $("#passdanhNhap").val();

    $.ajax({
        type: 'Post',
        url: '/DangNhap/LogJson',
        dataType: 'Json',
        data: { taikhoan: taikhoan, matkhau: matKhau },
        success: function (e) {
            if (e === "0") {
                alert("Tài Khoản Không Chính Xác");
            }
            else if (e === "1") {
                alert("Mật Khẩu Không chính Xác");
            }
            else if (e === "2") {
                location.href = "Product/Index";
            }
            else if (e === "3") {
                alert("Xin Chào Vui Lòng Đăng Nhập Tại Đây");
                location.href = "/QuanTri/DN";
            }
            else { }
        },
        error: function (e) {
            alert("Xin Lỗi Hệ Thống Đang Chẩn Bị Bảo Trì");
        }

    });
});

//phan lay lai mat khau 
$("#BtnLayPass").click(function () {
    var EmailLayPass = $("#EmailLayPass").val();
    var AccdanhNhap_Email = $("#AccdanhNhap_Email").val();
    $.ajax({
        type: 'Post',
        url: '/DangNhap/registGetPasswordrationJson',
        dataType: 'Json',
        data: { AccdanhNhap_Email: AccdanhNhap_Email, EmailLayPass: EmailLayPass },
        success: function (e) {
            if (e === "1") {
                alert("Tài Khoản Không Chính Xác");
            }
            else if (e === "2") {
                alert("Gmail Không chính Xác");
            }
            else if (e === "3") {
                alert("Vui Lòng Kiểm Tra Gmail");
                location.replace("https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            }
            else {
                alert("Xin Lỗi Hệ Thống Đang Chẩn Bị Bảo Trì");
            }
        },
        error: function (e) {
            alert("Xin Lỗi Hệ Thống Đang Chẩn Bị Bảo Trì");
        }

    });

});
//phan doi mat khau 


$("#btnChangePassword").click(function () {
    var taikhoanthaydoi = $("#taikhoanthaydoi").val();
    var passOld = $("#passOld").val();
    var passNew = $("#passNew").val();
    var PassAgain = $("#PassAgain").val();
    if (passNew === PassAgain) {
        $.ajax({
            type: 'Post',
            url: '/DangNhap/changePasswordJson',
            dataType: 'Json',
            data: {
                taikhoanthaydoi: taikhoanthaydoi, passOld: passOld, passNew: passNew
            },
            success: function (e) {
                if (e === "1") {
                    alert("Chỉ được Phép nhập a-z A-Z 0-9");
                }
                else if (e === "2") {
                    alert("Có Lỗi Hệ Thống Đang Bảo trì ");

                }
                else if (e === "3") {
                    alert("Tài Khoản Không Chính xác");
                }
                else if (e === "4") {
                    alert("Mật Khẩu Không Chính xác");
                }
                else if (e === "5") {
                    alert("Mật Khẩu Đã Thay đổi");
                    location.href = "/DangNhap/Log";
                }
                else {}
            },
            error: function (e) {

            }

        });
    }
    else {
        alert("Mật Khẩu Không Giống Nhau");
    }

})
//phan dang ky tai khoan 
$("#Btn_Registration").click(function () {
    var AccRegistration = $("#AccRegistration").val();
    var PassRegistration = $("#PassRegistration").val();
    var PassAgainRegistration = $("#PassAgainRegistration").val();
    var NameRegistration = $("#NameRegistration").val();
    var numberPhoneRegistration = $("#numberPhoneRegistration").val();
    var AdressRegistration = $("#AdressRegistration").val();
    var EmailRegistration = $("#EmailRegistration").val();
    if (PassRegistration === PassAgainRegistration) {
        $.ajax({
            type: 'Post',
            url: '/DangNhap/RegistrationJson',
            dataType: 'Json',
            data: {
                AccRegistration: AccRegistration, PassRegistration: PassRegistration,
                NameRegistration: NameRegistration, numberPhoneRegistration: numberPhoneRegistration,
                AdressRegistration: AdressRegistration, EmailRegistration: EmailRegistration
            },
            success: function (e) {
            },
            error: function (e) {

            }

        });
    }
    else {

    }


})