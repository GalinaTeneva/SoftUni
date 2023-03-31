namespace Theatre.Common
{
    public class ValidationConstants
    {
        //Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;

        public const int TheatreNumberOfHallsMinValue = 1;
        public const int TheatreNumberOfHallsMaxValue = 10;

        public const int TheatreDirectorNameMinLength = 4;
        public const int TheatreDirectorNameMaxLength = 30;

        //Tiket
        public const double TiketPriceMinValue = 1.00;
        public const double TiketPriceMaxValue = 100.00;

        public const int TicketRowNumberMinValue = 1;
        public const int TicketRowNumberMaxValue = 10;

        //Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;

        public const string CastPhoneNumberRegEx = @"\+44-\d{2}-\d{3}-\d{4}";

        //Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;

        public const float PlayRatingMinValue = 0.00f;
        public const float PlayRatingMaxValue = 10.00f;

        public const int PlayDescriptionMaxLength = 700;

        public const int PlayScreenwriterMinLength = 4;
        public const int PlayScreenwriterMaxLength = 30;
    }
}
