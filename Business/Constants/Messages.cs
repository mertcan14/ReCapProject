using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedSuccess = "Başarı ile eklendi";
        public static string AddedError = "Başarısız! Eklenemedi";

        public static string DeletedSuccess = "Başarı ile silindi";
        public static string DeletedError = "Başarısız! Silinemedi";

        public static string UpdateError = "Başarısız! Güncellenemedi";
        public static string UpdateSuccess = "Başarı ile güncellendi";

        public static string ListedSuccess = "Ürün listelendi.";
        public static string ListedError = "Ürün listelenemedi.";

        public static string ImageCount = "Maximum 5 tane olabilir";

        public static string NotFoundUser = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre hatalı";

        public static string LoginSuccess = "Giriş Başarılı";

        public static string UserAvailable = "Kullanıcı Mevcut";

        public static string CreatedToken = "Token Oluşturuldu";

        public static string AuthorizationDenied = "Yetkilenme Reddedildi";

        public static string CanRent = "Araç müsait";
        public static string CantRent = "Araç müsait değil";
    }
}
