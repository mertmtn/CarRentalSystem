using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class CarImageMessage
    {
        public static string CarImageAddedSuccessfully = "Araba resmi başarıyla eklendi.";
        public static string CarImageDeletedSuccessfully = "Araba resmi başarıyla silindi.";
        public static string CarImageUpdatedSuccessfully = "Araba resmi başarıyla güncellendi.";

        public static string CarImageLimitExceeded(int imageLimit)
        {
            return $"İlgili araba için yeni bir resim eklenemez. (En fazla eklenebilecek adet: {imageLimit})";
        }
    }
}