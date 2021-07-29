using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz";
        public static string CarNameLengthInvalid = "Ürün ismi en az 3 karakterli olmalı";
        public static string DailyPriceInvalid = "Araç kiralama fiyatı sıfırın altında olamaz";
        public static string MaintanceTime = "Sistem bakımda";
        public static string CarsListed = "Ürünler listelendi";

        public static string RentalAdded = "Araba kiralandı";
        public static string RentalsListed = "Kiralanan araç listesi";
        public static string RentalAddedError = "Araba kiralanamadı";
        public static string RentalDeleted = "Araba kiralanması silindi";
        public static string RentalUpdated = "Araba kiralanması güncellendi";
        public static string NotCarAvailable = "Araç başkası tarafından kiralanmış";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string CarImageAdded = "Araç resmi eklendi!";
        public static string CarImageUpdated = "Araç resmi güncellendi!";
        public static string CarImageDeleted = "Araç resmi silindi!";
        public static string CarImageCountExceeded = "Bir araca maksimum 5 resim eklenebilir!";
        public static string CarImageNotFound = "Araç resmi bulunamadı!";

        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        public static string CardExist = "Kredi kartı zaten var";

        public static string PaymentSuccessful = "Ödeme başarılı";
        public static string PaymentUnSeccessful = "Ödeme başarısız";

        public static string NoCar = "Araba bulanumadı";


        public static string AddSingular = " has been added.";
        public static string UpdateSingular = " has been updated.";
        public static string DeleteSingular = " has been deleted.";
        public static string NotExist = "There is no such a ";
    }
}
