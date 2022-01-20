function TempBasketInsert(ProductID, Name, Price, DiscountPrice, images) {
    $.ajax({
        type: "POST", // POST(Göndermek) Veya GET(Çekmek)
        url: "/JSONBasket/Olustur", // Hangi Adrese Gidecektir.
        data: '{ProductID:"' + ProductID + '",Name:"' + Name + '",Price:"' + Price + '",DiscountPrice:"' + DiscountPrice + '",images:"' + images + '",Piece:"1"}', // Hangi Bilgiler Gönderilecektir.
        contentType: "application/json; charset=utf-8", // Sayfa Yapısı
        dataType: "json", // Bu sayfanın içerisindeki Veri Yapısı

        success: function (cevap) { // if
            // Sorgu sorunsuz Çalıştıysa Burası Çalışacaktır.

            //$("#SepetRefresh").load("/PartialView/SepetAdetKontrol");
            $("#BasketRefresh").load("/PartialView/SepetAdetKontrol");
            $("#GelenCevap").html("<p>" + cevap + "</p>");
            $("#myModal").modal();
            //alert(cevap);
        },
        failure: function (cevap) {// else

            alert(cevap)
            // Sorgu Sorunluysa Burası Çalışacaktır.
        }
    });
}

function TempBasketDelete(TempBasketID) {
    $.ajax({
        type: "POST", // POST(Göndermek) Veya GET(Çekmek)
        url: "/JSONBasket/ProductDelete", // Hangi Adrese Gidecektir.
        data: '{TempBasketID:"' + TempBasketID + '"}', // Hangi Bilgiler Gönderilecektir.
        contentType: "application/json; charset=utf-8", // Sayfa Yapısı
        dataType: "json", // Bu sayfanın içerisindeki Veri Yapısı

        success: function(cevap) { // if
            // Sorgu sorunsuz Çalıştıysa Burası Çalışacaktır.
            $("#SepetRefresh").load("/PartialView/SepetAdetKontrol");
            $(location).attr("href", "/Basket");
        },
        failure: function(cevap) { // else

            alert(cevap);
            // Sorgu Sorunluysa Burası Çalışacaktır.
        }
    });
}

function AdetIslem(UrunID, Adet) {
    $.ajax({
        type: "POST", // POST(Göndermek) Veya GET(Çekmek)
        url: "/JSONBasket/ProductPiece", // Hangi Adrese Gidecektir.
        data: '{ProductID:"' + UrunID + '",Adet:"' + Adet + '"}', // Hangi Bilgiler Gönderilecektir.
        contentType: "application/json; charset=utf-8", // Sayfa Yapısı
        dataType: "json", // Bu sayfanın içerisindeki Veri Yapısı

        success: function(cevap) { // if
            // Sorgu sorunsuz Çalıştıysa Burası Çalışacaktır.
            $("#SepetRefresh").load("/PartialView/SepetAdetKontrol");
            $(location).attr("href", "/Basket");
        },
        failure: function(cevap) { // else
            alert(cevap);
            // Sorgu Sorunluysa Burası Çalışacaktır.
        }
    });
}