namespace Theatre.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Common;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);

            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();

            string[] validGenreTypes = new[] { "Drama", "Comedy", "Romance", "Musical" };
            ICollection<Play> validPlays = new List<Play>();

            foreach (ImportPlayDto playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validGenreTypes.Contains(playDto.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //float rating = float.Parse(playDto.Rating);

                //if (rating < ValidationConstants.PlayRatingMinValue || rating > ValidationConstants.PlayRatingMaxValue)
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                TimeSpan minDuration = new TimeSpan(1, 0, 0);

                Play play = new Play();
                play.Title = playDto.Title;
                play.Duration = TimeSpan.Parse(playDto.Duration);
                play.Rating = playDto.Rating;
                play.Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre);
                play.Description = playDto.Description;
                play.Screenwriter = playDto.Screenwriter;

                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre, playDto.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);

            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(reader);

            StringBuilder sb = new StringBuilder();

            ICollection<Cast> validCasts = new List<Cast>();
            foreach (ImportCastDto castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                };

                validCasts.Add(cast);

                string mainOrLesserChar = castDto.IsMainCharacter == true ? "main" : "lesser";

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, mainOrLesserChar));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            throw new NotImplementedException();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
