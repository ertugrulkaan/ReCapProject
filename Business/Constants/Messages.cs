using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    /// <summary>
    /// Sabit mesaj stringlerini tutar
    /// </summary>
    public static class Messages
    {
        #region CARMANAGERCONSTANTS
        public static string CarAdded = "Araba eklendi";
        public static string CarCannotAdded = "Araba eklenemedi";
        public static string CarDeleted = "Araba silindi";
        public static string CarCannotDeleted = "Araba silinemedi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarCannotUpdated = "Araba güncellenemedi";
        #endregion

        #region BRANDMANAGERCONSTANTS
        public static string BrandAdded = "Marka eklendi";
        public static string BrandCannotAdded = "Marka eklenemedi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandCannotDeleted = "Marka silinemedi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandCannotUpdated = "Marka güncellenemedi";

        #endregion

        #region COLORMANAGERCONSTANTS
        public static string ColorAdded = "Renk eklendi";
        public static string ColorCannotAdded = "Renk eklenemedi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorCannotDeleted = "Renk silinemedi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorCannotUpdated = "Renk güncellenemedi";
        #endregion

        #region USERMANAGERCONSTANTS
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserCannotAdded = "Kullanıcı eklenemedi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserCannotDeleted = "Kullanıcı silinemedi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserCannotUpdated = "Kullanıcı güncellenemedi";
        #endregion

        #region CUSTOMERMANAGERCONSTANTS
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerCannotAdded = "Müşteri eklenemedi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerCannotDeleted = "Müşteri silinemedi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerCannotUpdated = "Müşteri güncellenemedi";
        #endregion

        #region RENTALMANAGERCONSTANTS
        public static string CarRented = "Araba kiralandı";
        public static string CarCannotRented = "Araba kiralanamadı";
        public static string CarNotReturned = "Araba henüz teslim edilmedi";

        #endregion

        public static string MaintenanceTime = "Bakim saati islem yapilamaz";

    }
}
