

// các hàm kiểm  tra chung

//gmail

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


//sử lý phần đăng nhập 
$("#butDN").click(function () {
    var acc = $("#acc").val();
    var pass = $("#pass").val();
    if (acc === "" || acc == null || pass === "" || pass === null) {
        alert("Bạn Cần Nhập đầy đủ thông tin");
    }
    else {
        $.ajax({
            url: "/QuanTri/checkDN",
            type: "Post",
            dataType: "Json",
            data: { a: acc, p: pass },
            success: function (e) {
                if (e === "0") {
                    alert("Hệ Thống Đang Bảo Trì");
                }
                else if (e === "1") {
                    alert("Thông Tin Tài Khoản Mật Khảu không khớp");
                }
                else if (e === "2") {
                    location.replace("/adminpro/ADMinVip");
                }
                else if (e === "3") {
                    location.replace("/AdMin/TrangChu");
                }
                else if (e === "4") {
                    location.replace("/NhaCungCap/TrangChu");
                }
                else if (e === "5") {
                    alert("Tài Khoản Này Không có quyền Truy cập vào Đây");

                }
            },
            error: function (r) {
                alert(r);
            }
        });
    }
});

//su ly phan lay mat khau 
$("#butlmk").click(function () {
    var acc = $("#acc").val();
    var pass = $("#email2").val();
    if (acc === "" || acc == null || pass === "" || pass === null) {
        alert("Bạn Cần Nhập đầy đủ thông tin");
    }
    else {
        $.ajax({
            url: "/QuanTri/laymk",
            type: "Post",
            dataType: "Json",
            data: { taikhoan: acc, gmail: pass },
            success: function (e) {
                if (e === "0") {
                    alert("Tài Khoản Hoặc gmail Không chính xác");
                }
                else if (e === "1") {
                    location.replace("https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                }
                else if (e === "2") {
                    alert("Hệ Thống Đang Bảo trì");
                }
                else if (e === "3") {
                    alert("Tài Khoản hoặc gmail không chính xác ");
                }    
                else {
                    alert("chưa rõ truc trặc");
                }
            },
            error: function (r) {
                alert("Xin Lỗi Gặp Vấn đề");
            }
        });
    }
});
//su ly phan doi mat khau

$("#butdmk").click(function () {
    var acc = $("#acc").val();
    var pass = $("#pass").val();
    var passnew = $("#passnew").val();
    var passagain = $("#nhaplaimk").val();
    if (acc === "" || acc == null || pass === "" || pass === null || passagain === "" || passagain == null || passnew === "" || passnew === null) {
        alert("Bạn Cần Nhập đầy đủ thông tin");
    }
    else {
        if (passnew !== passagain) {
            alert("Mật Khẩu Không Khớp");
        }
        else {
            $.ajax({
                url: "/QuanTri/doimk",
                type: "Post",
                dataType: "Json", 
                data: { taikhoan: acc, mkcu: pass, mkmoi: passnew },
                success: function (e) {
                    if (e === "2") {
                        alert("Tài Khoản Hoặc Mật Khẩu Không Chính Xác");
                    } else if (e === "1") {
                       
                        alert("Đổi Mật Khẩu Thành Công Vui Lòng Đăng Nhập Xác Nhận");

                    } else if (e === "3") {
                        alert("Lỗi Hệ thống");
                    }

                },
                error: function (r) {
                    alert("Xin Lỗi Gặp Vấn đề");
                }
            });
        }
        
    }
});