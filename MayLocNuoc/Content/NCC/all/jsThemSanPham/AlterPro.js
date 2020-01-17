$("#ChinhSuaProduct").click(function () {
    var ID_product_Supplier = $('#ID_product_Supplier').val();
    var name_product = $('#name_product').val();
    var length_product = $('#length_product').val();
    var with_product = $('#with_product').val();
    var height_product = $('#height_product').val();
    var title_product = $('#title_product').val();
    var number_product = $('#number_product').val();
    var core_product = $('#core_product').val();
    var producttion_product = $('#producttion_product').val();
    var speed_product = $('#speed_product').val();
    var technology_product = $('#technology_product').val();
    var pump_product = $('#pump_product').val();
    var price_product = $('#price_product').val();
    var free_product = $('#free_product').val();
    var number_free_product = $('#number_free_product').val();
    var brand_product = $('#brand_product').val();
    var quality_product = $('#quality_product').val();
    var where_production = $('#where_production').val();
    if (name_product == null || name_product == "" ||
        length_product == null || length_product == "" ||
        with_product == null || with_product == "" ||
        height_product == null || height_product == "" ||
        title_product == null || title_product == "" ||
        number_product == null || number_product == "" ||
        core_product == null || core_product == "" ||
        producttion_product == null || producttion_product == "" ||
        speed_product == null || speed_product == "" ||
        technology_product == null || technology_product == "" ||
        pump_product == null || pump_product == "" ||
        price_product == null || price_product == "" ||
        brand_product == null || brand_product == "" ||
        quality_product == null || quality_product == "" ||
        where_production == null || where_production == "" ||
        ID_product_Supplier == null || ID_product_Supplier == ""
    ) {
        alert("Bạn Cần Nhập Đầy Đủ Thông Tin - Mã Giảm Giá có thể cho qua ");
    }
    else {
        var Imgchinh = $("#ImgShowChinh").attr("src");
        var Img2 = $("#ImgShowMat2").attr("src");
        var Img3 = $("#ImgShowMat3").attr("src");
        var Img4 = $("#ImgShowMat4").attr("src");
        var Img1 = $("#ImgShowMat1").attr("src");
        if (Imgchinh == "" || Imgchinh == null ||
            Img2 == "" || Img2 == null ||
            Img3 == "" || Img3 == null ||
            Img4 == "" || Img4 == null ||
            Img1 == "" || Img1 == null) {
            alert("Ảnh chưa được tải lên");
        } else {
            $.ajax({
                type: 'Post',
                url: '/NhaCungCap/ChinhSuaProduct',
                dataType: 'Json',
                data: {
                    ID_product_Supplier: ID_product_Supplier ,
                    name_product: name_product,
                    length_product: length_product,
                    with_product: with_product,
                    height_product: height_product,
                    title_product: title_product,
                    number_product: number_product,
                    core_product: core_product,
                    producttion_product: producttion_product,
                    speed_product: speed_product,
                    technology_product: technology_product,
                    pump_product: pump_product,
                    price_product: price_product,
                    brand_product: brand_product,
                    quality_product: quality_product,
                    where_production: where_production,
                    free_product: free_product,
                    number_free_product: number_free_product,
                    Imgchinh: Imgchinh,
                    Img1: Img1,
                    Img2: Img2,
                    Img3: Img3,
                    Img4: Img4
                },
                success: function (e) {
                    if (e === "1") {
                        location.replace("/QuanTri/DN");
                    }
                    else if (e === "2") {
                        location.replace("/DangNhap/Info");
                    }
                    else if (e === "3") {
                        alert("Hãy Xem lại Dữ liệu");
                    }
                    else if (e === "4") {
                        alert("Thành Công");
                    }
                    else {
                        
                    }
                },
                error: function () {
                    alert("loi");
                }
            });
        }

    }
});
