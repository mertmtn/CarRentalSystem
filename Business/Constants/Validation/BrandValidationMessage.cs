 namespace Business.Constants.Validation
{
    public static class BrandValidationMessage
    {
        public static string BrandNameNotEmpty = "Marka ismini giriniz!";

        public static string BrandNameLength(int minLength, int maxLength)
        {
            return $"Marka ismini {minLength} ile {maxLength} karakter arasında giriniz!";
        }
    }
}
